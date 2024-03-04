using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.ClassDto;

public class ClassCreateDto
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
    public string Name { get; set; }
    public int TotalAmount { get; set; }
    public int Status { get; set; }
}
