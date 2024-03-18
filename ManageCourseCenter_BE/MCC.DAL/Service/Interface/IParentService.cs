using MCC.DAL.Common;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ParentDto;

namespace MCC.DAL.Service.Interface;

public interface IParentService
{
    Task<AppActionResult> GetAllParentAsync();
    Task<AppActionResult> GetParentByIdAsync(int id);
    Task<AppActionResult> GetParentByNameAsync(string name);
    Task<AppActionResult> GetChildWithParentId(int id);
    Task<AppActionResult> GetChildWithParentEmail(string email);
    Task<AppActionResult> CreateParentAsync(ParentCreateDto parentCreateDto);
    Task<AppActionResult> GetParentByEmailAndPasswordAsync(string email, string password);
    Task<AppActionResult> GetAllChildrenByParentId(int id, int pageIndex, int pageSize);
    Task<AppActionResult> CountNumberParent();
    Task<AppActionResult> UpdateParentInformationAsync(ParentUpdateDto parentUpdateDto);
    Task<AppActionResult> CreateChildrenWithParentID(int parentId, ChildCreatDto childCreateDto);



}
