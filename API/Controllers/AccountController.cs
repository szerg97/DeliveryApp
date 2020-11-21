using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Interfaces;
using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            if (await UserExists(dto.UserName)) return BadRequest("Username is taken.");

            var user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = dto.UserName.ToLower(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded) BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) BadRequest(roleResult.Errors);

            return new UserDto() { UserName = user.UserName,FirstName=user.FirstName, LastName = user.LastName, 
                Gender = user.Gender, Token = await _tokenService.CreateToken(user), DateOfBirth = user.DateOfBirth};
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto dto)
        {
            var user = await _userManager.Users
                .Include(u => u.Offers)
                .Include(u => u.Feedbacks)
                .Include(u => u.Companies)
                .SingleOrDefaultAsync(x => x.UserName == dto.UserName.ToLower());

            if (user == null) return Unauthorized("Invalid username");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded) return Unauthorized();
            return new UserDto() { Id = user.Id, UserName = user.UserName, Token = await _tokenService.CreateToken(user),
            FirstName = user.FirstName, LastName = user.LastName, Gender = user.Gender, DateOfBirth = user.DateOfBirth, Role = user.UserRoles.FirstOrDefault().Role.Name};
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}