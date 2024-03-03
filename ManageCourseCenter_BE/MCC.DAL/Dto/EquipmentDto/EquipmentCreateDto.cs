using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.EquipmentDto;

public class EquipmentCreateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Type { get; set; }
    public int Status { get; set; }
}

