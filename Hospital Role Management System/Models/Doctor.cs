using System;
using System.Collections.Generic;

namespace Hospital_Role_Management_System.Models
{
    public partial class Doctor
    {
        public string DoctorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
