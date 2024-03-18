namespace MCC.DAL.Dto.FeedbackDto;

public class FeedbackUpdateDto
{
    public int Id { get; set; }
    public int CourseRating { get; set; }
    public int TeacherRating { get; set; }
    public int EquipmentRating { get; set; }
    public string Description { get; set; }
}
