﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MessageDto
    {
        public string MessageId { get; set; }
        public string SenderId { get; set; }
        public string SenderUserName { get; set; }
        public string RecipientId { get; set; }
        public string RecipientUserName { get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public DateTime? DateRead { get; set; }
        public DateTime MessageSent { get; set; }
    }
}
