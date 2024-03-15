using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentActivities = new HashSet<EquipmentActivity>();
            EquipmentReports = new HashSet<EquipmentReport>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }

        public virtual ICollection<EquipmentActivity> EquipmentActivities { get; set; }
        public virtual ICollection<EquipmentReport> EquipmentReports { get; set; }
    }
}
