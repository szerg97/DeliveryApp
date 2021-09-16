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
                Console.WriteLine(user.FirstName);

                await userManager.CreateAsync(user, "password");
                await userManager.AddToRoleAsync(user, "Member");
            }

            var admin = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "admin",
                FirstName = "Admin",
                LastName = "Admin"
            };

            await userManager.CreateAsync(admin, "password");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Member" });
        }

        public static async Task SeedOffers (ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (await context.Offers.AnyAsync()) return;

            List<AppUser> users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                Company company = await context.Companies.FirstOrDefaultAsync(x => x.Creator == user);

                context.Offers.Add(new Offer()
                {
                    OfferId = Guid.NewGuid().ToString(),
                    Creator = user,
                    FromZip = "5500",
                    FromCity = "Prague",
                    FromCountry = "Czech Republic",
                    ToZip = "6800",
                    ToCity = "Wien",
                    ToCountry = "Austria",
                    Registered = DateTime.Now,
                    Status = "Pending",
                    Solution = "air",
                    Text = "I would like to deliver .... Thanks!",
                    Company = company
                });

                context.Offers.Add(new Offer()
                {
                    OfferId = Guid.NewGuid().ToString(),
                    Creator = user,
                    FromZip = "9600",
                    FromCity = "Gyõr",
                    FromCountry = "Hungary",
                    ToZip = "3200",
                    ToCity = "Bratislava",
                    ToCountry = "Slovakia",
                    Registered = DateTime.Now,
                    Status = "Pending",
                    Solution = "road",
                    Text = "I would like to deliver .... Thanks!",
                    Company = company
                });

                context.Offers.Add(new Offer()
                {
                    OfferId = Guid.NewGuid().ToString(),
                    Creator = user,
                    FromZip = "11900",
                    FromCity = "Warsaw",
                    FromCountry = "Poland",
                    ToZip = "98900",
                    ToCity = "Berlin",
                    ToCountry = "Germany",
                    Registered = DateTime.Now,
                    Status = "Completed",
                    Solution = "rail",
                    Text = "I would like to deliver .... Thanks!",
                    Company = company
                });

                await context.SaveChangesAsync();
            }
            
        }

        public static async Task SeedFeedbacks(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (await context.Feedbacks.AnyAsync()) return;

            List<AppUser> users = await userManager.Users.ToListAsync();

            await context.Feedbacks.AddAsync(new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Creator = users.ToArray()[0],
                Date = DateTime.Now,
                Solution = "air",
                Value = 5,
                Text = "The air freight is a very cool thing! :)"
            });

            await context.Feedbacks.AddAsync(new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Creator = users.ToArray()[1],
                Date = DateTime.Now,
                Solution = "sea",
                Value = 4,
                Text = "I asked for the delivery on sea and I am really satisfied!"
            });

            await context.Feedbacks.AddAsync(new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Creator = users.ToArray()[2],
                Date = DateTime.Now,
                Solution = "road",
                Value = 5,
                Text = "The delivery was soo fast!"
            });

            await context.Feedbacks.AddAsync(new Feedback()
            {
                Id = Guid.NewGuid().ToString(),
                Creator = users.ToArray()[3],
                Date = DateTime.Now,
                Solution = "air",
                Value = 5,
                Text = "OMG so massive service :o"
            });

            await context.SaveChangesAsync();
        }

        public static async Task SeedCompanies(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            if (await context.Companies.AnyAsync()) return;

            List<AppUser> users = await userManager.Users.ToListAsync();
            foreach (var user in users)
            {
                context.Companies.Add(new Company()
                {
                    CompanyId = Guid.NewGuid().ToString(),
                    Creator = user,
                    Registered = DateTime.Now,
                    CompanyName = user.FirstName + "'s Company Ltd.",
                    CompanyCountry = "Austria",
                    CompanyZip = "19000",
                    NumberOfEmployees = 250
                });

                context.Companies.Add(new Company()
                {
                    CompanyId = Guid.NewGuid().ToString(),
                    Creator = user,
                    Registered = DateTime.Now,
                    CompanyName = user.FirstName + " Industries",
                    CompanyCountry = "Budapest",
                    CompanyZip = "1032",
                    NumberOfEmployees = 180
                });

                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedCountries(ApplicationDbContext context)
        {
            if (await context.Countries.AnyAsync()) return;

            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Austria",
                Region = "Central Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Slovakia",
                Region = "Central Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Slovenia",
                Region = "Central Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Hungary",
                Region = "Central Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Italy",
                Region = "Southern Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Germany",
                Region = "Western Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "France",
                Region = "Western Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Poland",
                Region = "Central Europe"
            });
            context.Countries.Add(new Country()
            {
                CountryId = Guid.NewGuid().ToString(),
                CountryName = "Croatia",
                Region = "Southern Europe"
            });

            await context.SaveChangesAsync();
        }
    }
}