using System;
using System.Collections.Generic;

namespace A2.Models
{
    public partial class Login
    {
        public string LoginName { get; set; }
        public string Password { get; set; }

        public Student LoginNameNavigation { get; set; }
    }
}
