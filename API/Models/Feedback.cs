using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Feedback
    {
        [Key]
        public string Id { get; set; }

        [Range(1,5)]
        public int Value { get; set; }

        [StringLength(50)]
        public string Solution { get; set; }

        [StringLength(800)]
        public string Text { get; set; }

        [ForeignKey("Creator")]
        public string CreatorId { get; set; }

        public DateTime Date { get; set; }

        public virtual AppUser Creator { get; set; }
    }
}
