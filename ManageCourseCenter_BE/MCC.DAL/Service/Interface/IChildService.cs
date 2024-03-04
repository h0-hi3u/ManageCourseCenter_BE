﻿using MCC.DAL.Common;
using MCC.DAL.Dto.ChildDto;

namespace MCC.DAL.Service.Interface;

public interface IChildService
{
    Task<AppActionResult> GetAllChildAsync();
    Task<AppActionResult> GetChildByIdAsync(int id);
    Task<AppActionResult> GetChildByNameAsync(string name);
    Task<AppActionResult> CreateChildAsync(ChildCreatDto childCreatDto);
}
