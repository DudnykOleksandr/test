﻿using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Contact
    {
        public Guid ContactId { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer Customer { get; set; }
    }
}
