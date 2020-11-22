using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Offer
    {
        [Key]
        public string OfferId { get; set; }
        public string FromCity { get; set; }
        public string FromCountry { get; set; }
        public string FromZip { get; set; }
        public string ToCity { get; set; }
        public string ToCountry { get; set; }
        public string ToZip { get; set; }
        public string Solution { get; set; }
        public string Text { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime Registered { get; set; }

        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        [ForeignKey("Company")]
        public string CompanyId { get; set; }

        public virtual AppUser Creator { get; set; }

        public virtual Company Company { get; set; }
    }
}
