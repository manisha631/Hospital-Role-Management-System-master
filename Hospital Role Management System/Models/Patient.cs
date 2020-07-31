using System;
using System.Collections.Generic;

namespace Hospital_Role_Management_System.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Doctor = new HashSet<Doctor>();
            Room = new HashSet<Room>();
        }

        public string PatientId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Disease { get; set; }

        public virtual ICollection<Doctor> Doctor { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
