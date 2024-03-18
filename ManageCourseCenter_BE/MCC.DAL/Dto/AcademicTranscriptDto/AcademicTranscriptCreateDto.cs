using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.AcademicTranscriptDto;

public class AcademicTranscriptCreateDto
{
    public int TeacherId { get; set; }
    public int CourseId { get; set; }
    public int ChildrenId { get; set; }
    public decimal Quiz1 { get; set; }
    public decimal Quiz2 { get; set; }
    public decimal Midterm { get; set; }
    public decimal Final { get; set; }
    //public decimal Average { get; set; }
    public int Status { get; set; }
}
