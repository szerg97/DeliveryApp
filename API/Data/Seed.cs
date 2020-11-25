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

        public static async Task SeedSites(ApplicationDbContext context)
        {
            if (await context.Sites.AnyAsync()) return;

            context.Sites.Add(new Site
            {
                SiteId = Guid.NewGuid().ToString(),
                Address = "Hunyadi Mátyás street 58",
                City = "Budapest",
                Zip = "1146",
                Country = "Hungary",
                SiteName = "WD Logistics HQ Budapest"
            });
            context.Sites.Add(new Site
            {
                SiteId = Guid.NewGuid().ToString(),
                Address = "Ady Endre street 112",
                City = "Budapest",
                Zip = "1082",
                Country = "Hungary",
                SiteName = "WD Logistics Manufacture"
            });
            context.Sites.Add(new Site
            {
                SiteId = Guid.NewGuid().ToString(),
                Address = "Petõfi Sándor street 6/B",
                City = "Debrecen",
                Zip = "4024",
                Country = "Hungary",
                SiteName = "WD Logistics Manufacture"
            });
            context.Sites.Add(new Site
            {
                SiteId = Guid.NewGuid().ToString(),
                Address = "Podmanicky street 78",
                City = "Bratislava",
                Zip = "8974",
                Country = "Slovakia",
                SiteName = "WD Logistics Bratislava"
            });

            await context.SaveChangesAsync();
        }
    }
}