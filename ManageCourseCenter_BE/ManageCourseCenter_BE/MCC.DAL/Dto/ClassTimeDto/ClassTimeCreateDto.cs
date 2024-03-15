namespace MCC.DAL.Dto.ClassTimeDto;

public class ClassTimeCreateDto
{
    public int ClassId { get; set; }
    public string DayInWeek { get; set; }
    public string StarTime { get; set; }
    public string EndTime { get; set; }
}
