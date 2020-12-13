using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string,
        IdentityUserClaim<string>, AppUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Offer>()
                .HasOne(o => o.Creator)
                .WithMany(c => c.Offers)
                .HasForeignKey(o => o.CreatorId);

            builder.Entity<Feedback>()
                .HasOne(o => o.Creator)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(o => o.CreatorId);

            builder.Entity<Company>()
                .HasOne(o => o.Creator)
                .WithMany(c => c.Companies)
                .HasForeignKey(o => o.CreatorId);

            builder.Entity<AppUser>()
                .HasMany(o => o.Feedbacks)
                .WithOne(o => o.Creator)
                .HasForeignKey(o => o.CreatorId);

            builder.Entity<AppUser>()
                .HasMany(o => o.Offers)
                .WithOne(o => o.Creator)
                .HasForeignKey(o => o.CreatorId);
            
            builder.Entity<AppUser>()
                .HasMany(o => o.Companies)
                .WithOne(o => o.Creator)
                .HasForeignKey(o => o.CreatorId);
            
            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<Message>()
                .HasOne(u => u.Recipient)
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>()
               .HasOne(u => u.Sender)
               .WithMany(m => m.MessagesSent)
               .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
