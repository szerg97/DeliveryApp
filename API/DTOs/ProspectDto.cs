using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ProspectDto
    {
        public string FromCity { get; set; }
        public string FromCountry { get; set; }
        public string FromZip { get; set; }
        public string ToCity { get; set; }
        public string ToCountry { get; set; }
        public string ToZip { get; set; }
        public string Solution { get; set; }
        public string Text { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyZip { get; set; }
        public int NumberOfEmployees { get; set; }
        public string CreatorId { get; set; }
        public string Status { get; set; }
    }
}
