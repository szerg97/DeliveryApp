using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FeedbacksController : BaseApiController
    {
        private  ApplicationDbContext _context;
        private  UserManager<AppUser> _userManager;

        public FeedbacksController(ApplicationDbContext context,
            UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Feedback>>> GetFeedbacks()
        {
            return await _context.Feedbacks.OrderByDescending(x => x.Date).ToListAsync();
        }


        [Authorize(Roles = "Member")]
        [HttpPost("add-feedback")]
        public async Task<ActionResult<FeedbackDto>> AddFeedback(FeedbackDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Problem adding a feedback.");
            }

            Feedback feedback = new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Date = DateTime.Now,
                Text = dto.Text,
                Value = dto.Value,
                CreatorId = dto.CreatorId,
                Solution = dto.Solution
            };

            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();

            return new FeedbackDto(){CreatorId = feedback.CreatorId, Text = feedback.Text, Value = feedback.Value, Solution = feedback.Solution};
        }
    }
}