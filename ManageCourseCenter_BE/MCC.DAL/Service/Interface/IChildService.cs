﻿using MCC.DAL.Common;
using MCC.DAL.Dto.ChildDto;

namespace MCC.DAL.Service.Interface;

public interface IChildService
{
    Task<AppActionResult> GetAllChildAsync();
    Task<AppActionResult> GetChildByIdAsync(int id);
    Task<AppActionResult> GetChildByNameAsync(string name);
    Task<AppActionResult> CreateChildAsync(ChildCreatDto childCreatDto);
    Task<AppActionResult> UpdateChildAsync(ChildUpdateDto childUpdateDto);
    Task<AppActionResult> GetChildrenByUsernameAndPasswordAsync(string username, string password);
    Task<AppActionResult> Authenticate(string username, string password);
    Task<AppActionResult> CountNumberChildrent();
    Task<AppActionResult> GetAllChildPagingAsync(int pageSize, int pageIndex);
    Task<AppActionResult> GetChildrenListNotEnrollCourseAsync(int parentId, int courseId, int pageIndex, int pageSize);

    Task<AppActionResult> CreateChildrenWithParentID(int parentId, ChildCreatDto childCreateDto);
    Task<AppActionResult> GetAllChildrenByParentId(int id, int pageIndex, int pageSize);
    Task<AppActionResult> UpdateChildrenOfAParent(int parentId, IEnumerable<ChildUpdateDto> childUpdates);
    Task<AppActionResult> GetAllChildByClassId(int classId);
}
