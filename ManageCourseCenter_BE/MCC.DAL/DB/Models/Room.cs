using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Room
    {
        public Room()
        {
            EquipmenntActivities = new HashSet<EquipmenntActivity>();
            EquipmentReports = new HashSet<EquipmentReport>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int Floor { get; set; }
        public int RoomNo { get; set; }
        public int Status { get; set; }

        public virtual ICollection<EquipmenntActivity> EquipmenntActivities { get; set; }
        public virtual ICollection<EquipmentReport> EquipmentReports { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
