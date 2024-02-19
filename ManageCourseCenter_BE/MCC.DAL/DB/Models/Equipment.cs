using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmenntActivities = new HashSet<EquipmenntActivity>();
            EquipmentReports = new HashSet<EquipmentReport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }

        public virtual ICollection<EquipmenntActivity> EquipmenntActivities { get; set; }
        public virtual ICollection<EquipmentReport> EquipmentReports { get; set; }
    }
}
