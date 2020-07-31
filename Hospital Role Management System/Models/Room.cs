using System;
using System.Collections.Generic;

namespace Hospital_Role_Management_System.Models
{
    public partial class Room
    {
        public string RoomId { get; set; }
        public string RoomStatus { get; set; }
        public int RoomFloorNo { get; set; }
        public string PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
