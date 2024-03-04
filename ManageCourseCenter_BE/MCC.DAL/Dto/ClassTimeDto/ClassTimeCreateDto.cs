namespace MCC.DAL.Dto.ClassTimeDto;

public class ClassTimeCreateDto
{
    public int ClassId { get; set; }
    public string DayInWeek { get; set; }
    public TimeSpan StarTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
