using API.Extensions;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class AppUser : IdentityUser<string>
    {
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }

        public AppUser()
        {
            Feedbacks = new HashSet<Feedback>();
            Companies = new HashSet<Company>();
            Offers = new HashSet<Offer>();
            UserRoles = new HashSet<AppUserRole>();
        }

        public int GetAge()
        {
            return DateOfBirth.CalculateAge();
        }

        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
    }
}
