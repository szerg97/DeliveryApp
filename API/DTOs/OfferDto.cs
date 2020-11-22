using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class OfferDto
    {
        public string OfferId { get; set; }
        public string FromCity { get; set; }
        public string FromCountry { get; set; }
        public string FromZip { get; set; }
        public string ToCity { get; set; }
        public string ToCountry { get; set; }
        public string ToZip { get; set; }
        public string Solution { get; set; }
        public string Text { get; set; }
        public DateTime Registered { get; set; }
        public string CreatorName { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
    }
}
