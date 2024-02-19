using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class EquipmenntActivity
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }
        public int EquipmentId { get; set; }
        public int RoomId { get; set; }
        public DateTime OperateTime { get; set; }
        public int Action { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Room Room { get; set; }
    }
}
