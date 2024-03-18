using MCC.DAL.Common;
using MCC.DAL.Dto.ClassTimeDto;

namespace MCC.DAL.Service.Interface;

public interface IClassTimeService
{
    Task<AppActionResult> GetClassTimeByClassIdAsync(int classId);
    Task<AppActionResult> GetClassTimeByClassName(string className);
    Task<AppActionResult> CreateClassTimeAsync(ClassTimeCreateDto classTimeCreateDto);
    Task<AppActionResult> UpdateClassTimeAsync(ClassTimeUpdateDto classTimeUpdateDto);
}
