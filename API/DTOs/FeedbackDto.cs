using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FeedbackDto
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public string Solution { get; set; }
        public string CreatorId { get; set; }
    }
}
