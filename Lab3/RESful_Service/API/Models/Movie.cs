﻿using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Rates = new HashSet<Rate>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public int? GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
    }
}
