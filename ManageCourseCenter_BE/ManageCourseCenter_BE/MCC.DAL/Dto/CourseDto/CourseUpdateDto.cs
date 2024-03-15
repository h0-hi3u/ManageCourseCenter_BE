using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.CourceDto;

public class CourseUpdateDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public DateTime OpenFormTime { get; set; }
    public DateTime CloseFormTime { get; set; }
    public double? Price { get; set; }
    public int Level { get; set; }
    public int TotalSlot { get; set; }
    public int Status { get; set; }
}
