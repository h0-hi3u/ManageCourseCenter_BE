﻿using MCC.DAL.Common;
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
}
