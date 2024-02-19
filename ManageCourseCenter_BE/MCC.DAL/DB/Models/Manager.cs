using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Manager
    {
        public Manager()
        {
            EquipmenntActivities = new HashSet<EquipmenntActivity>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<EquipmenntActivity> EquipmenntActivities { get; set; }
    }
}
