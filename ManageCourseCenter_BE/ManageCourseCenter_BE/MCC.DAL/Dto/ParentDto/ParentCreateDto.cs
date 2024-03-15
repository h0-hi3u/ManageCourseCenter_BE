namespace MCC.DAL.Dto.ParentDto;

public class ParentCreateDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ImgUrl { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
    public int Role { get; set; }
    public int Status { get; set; }
}
