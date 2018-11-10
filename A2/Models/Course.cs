using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Course
    {
        public string CourseCode { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string CourseTitle { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
