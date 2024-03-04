using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.EquipmentDto;

public class EquipmentActivityCreateDto
{
    public int ManagerId { get; set; }
    public int EquipmentId { get; set; }
    public int RoomId { get; set; }
    public DateTime OperateTime { get; set; }
    public string Description { get; set; }
    public int Action { get; set; }
}
