using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager){
            if (await userManager.Users.AnyAsync()) return;
            
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");

            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            if (users == null) return;

            var roles = new List<AppRole>
            {
                new AppRole(){Id = Guid.NewGuid().ToString(), Name = "Member"},
                new AppRole(){Id = Guid.NewGuid().ToString(), Name = "Admin"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.Id = Guid.NewGuid().ToString();
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "password");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "password");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Member" });
        }

        public static async Task SeedCountries(ApplicationDbContext context){
            if (await context.Countries.CountAsync() != 0) return;

            await context.Countries.AddAsync(new Country(){CountryId = "1", CountryName = "Hungary", Region = "Central Europe"});
            await context.Countries.AddAsync(new Country(){CountryId = "2", CountryName = "Austria", Region = "Central Europe"});
            await context.Countries.AddAsync(new Country(){CountryId = "3", CountryName = "Slovakia", Region = "Central Europe"});
            await context.Countries.AddAsync(new Country(){CountryId = "4", CountryName = "Slovenia", Region = "Central Europe"});

            await context.SaveChangesAsync();
        }
    }
}