using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.ClassTimeDto;

public class ClassTimeUpdateDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string DayInWeek { get; set; }
    public TimeSpan StarTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
