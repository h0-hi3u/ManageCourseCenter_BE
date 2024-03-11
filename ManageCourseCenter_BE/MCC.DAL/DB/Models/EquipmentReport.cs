using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class EquipmentReport
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public int Status { get; set; }

        public virtual Equipment Equipment { get; set; }
        public virtual Room Room { get; set; }
        public virtual Teacher Sender { get; set; }
    }
}
