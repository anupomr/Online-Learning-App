using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Student
    {
        public Student()
        {
            Appoinment = new HashSet<Appoinment>();
            Course = new HashSet<Course>();
            Rating = new HashSet<Rating>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Program { get; set; }

        public Login Login { get; set; }
        public ICollection<Appoinment> Appoinment { get; set; }
        public ICollection<Course> Course { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
