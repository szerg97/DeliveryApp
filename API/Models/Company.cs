using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Company
    {
        [Key]
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyZip { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime Registered { get; set; } = DateTime.Now;

        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        public virtual AppUser Creator { get; set; }

        public static implicit operator List<object>(Company v)
        {
            throw new NotImplementedException();
        }
    }
}
