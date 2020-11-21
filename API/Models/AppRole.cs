using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AppRole : IdentityRole<string>
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }

        public AppRole()
        {
            UserRoles = new HashSet<AppUserRole>();
        }
    }
}
