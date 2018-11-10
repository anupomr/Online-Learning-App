using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Rating
    {
        public string RatingId { get; set; }
        public string StudentId { get; set; }
        public string Comment { get; set; }

        public Student Student { get; set; }
    }
}
