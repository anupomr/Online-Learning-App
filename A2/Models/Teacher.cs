using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Appoinment = new HashSet<Appoinment>();
            Course = new HashSet<Course>();
        }

        public string TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TeacherResume { get; set; }
        public string School { get; set; }
        public string Department { get; set; }

        public ICollection<Appoinment> Appoinment { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
