using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Appoinment
    {
        public string AppoinmentId { get; set; }
        public string StudentId { get; set; }
        public string TeacherId { get; set; }
        public string AppoinmentDate { get; set; }
        public string AppoinmentTime { get; set; }
        public string AppoinmentCoz { get; set; }

        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
    }
}
