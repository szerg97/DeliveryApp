using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CompanyDto
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCountry { get; set; }
        public string CompanyZip { get; set; }
        public int NumberOfEmployees { get; set; }
        public DateTime Registered { get; set; }
    }
}
