namespace MCC.DAL.Dto.ChildDto;

public class ChildCreatDto
{
    public int ParentId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
    public int Role { get; set; }
    public int Status { get; set; }
}
