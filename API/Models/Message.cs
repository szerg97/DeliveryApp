using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Message
    {
        public string MessageId { get; set; }
        public string SenderId { get; set; }
        public string SenderUserName { get; set; }
        public virtual AppUser Sender { get; set; }
        public string RecipientId { get; set; }
        public string RecipientUserName { get; set; }
        public virtual AppUser Recipient { get; set; }
        public string Content { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; } = DateTime.Now;
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}
