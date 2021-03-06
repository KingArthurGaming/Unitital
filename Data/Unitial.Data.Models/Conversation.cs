﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unitial.Data.Models
{
    public class Conversation
    {
        public Conversation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.LastUpdate = DateTime.UtcNow;
            this.Messages = new HashSet<Message>();
        }
        public string Id { get; set; }
        public string FirstUserId { get; set; }
        public string SecondUserId { get; set; }
        public bool SeenFirstUser { get; set; }
        public bool SeenSecondUser { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

    }
}
