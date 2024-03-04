using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.EquipmentDto;

public class EquipmentReportCreateDto
{
    public int RoomId { get; set; }
    public int EquipmentId { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
}
