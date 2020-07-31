using System;
using System.Collections.Generic;

namespace Hospital_Role_Management_System.Models
{
    public partial class AdminLogin
    {
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }
    }
}
