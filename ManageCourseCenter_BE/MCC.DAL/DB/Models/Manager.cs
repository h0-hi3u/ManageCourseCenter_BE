using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Manager
    {
        public Manager()
        {
            EquipmentActivities = new HashSet<EquipmentActivity>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<EquipmentActivity> EquipmentActivities { get; set; }
    }
}
