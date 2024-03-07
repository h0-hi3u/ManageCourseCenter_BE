using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.CartDto;

public class CartCreateDto
{
    public int ParentId { get; set; }
    public int Status { get; set; }
}
