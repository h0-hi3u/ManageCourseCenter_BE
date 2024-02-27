using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.ManagerDto;

public class ManagerShowResponseDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DateTime BirthDay { get; set; }
    public int Gender { get; set; }
    public int Role { get; set; }
    public int Status { get; set; }
}
