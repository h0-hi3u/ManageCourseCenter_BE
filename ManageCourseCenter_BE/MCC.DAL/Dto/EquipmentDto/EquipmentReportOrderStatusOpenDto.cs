using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.EquipmentDto
{
    public class EquipmentReportOrderStatusOpenDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }
        public string Description { get; set; }
        public DateTime SendTime { get; set; }
        public DateTime? CloseTime { get; set; }
        public int Status { get; set; }
    }
}
