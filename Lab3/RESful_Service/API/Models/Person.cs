﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Person
    {
        public Person()
        {
            Rates = new HashSet<Rate>();
        }

        public int PersonId { get; set; }
        public string Fullname { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}
