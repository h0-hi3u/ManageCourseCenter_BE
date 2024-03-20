using MCC.DAL.Common;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.EquipmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface IEquipmentActivityService
{
    Task<AppActionResult> GetAllEquipmentActivityAsync();
    Task<AppActionResult> GetEquipmentByEquipmentId(int equipmentId);
    Task<AppActionResult> GetEquipmentByManagerId(int managerId);
    Task<AppActionResult> GetEquipmentByRoomId(int roomId);
    Task<AppActionResult> GetEquipmentByRoomNo(int roomNo);
    Task<AppActionResult> GetEquipmentByTimeRange(DateTime from, DateTime to);
    Task<AppActionResult> GetLatestActivityByEquipmentId(int equipmentId);
    Task<int> GetLatestActivityIdByEquipmentId(int equipmentId);
    Task<AppActionResult> CreateEquipmentActivityAsync(EquipmentActivityCreateDto equipActivityCreateDto);
    Task<AppActionResult> CreateMovingActivityForEquipmentAsync(int equipmentId, int managerId, int newRoomId);
    Task<AppActionResult> CreateMaintainActivityForEquipmentAsync(int equipmentId, int managerId, int roomId);
    Task<AppActionResult> UpdateEquipmentActivityFinishedTimeAsync(int id);
    Task<AppActionResult> UpdateEquipmentActivityDescriptionAsync(EquipmentActivityUpdateDescriptiomDto equipmentActivityUpdateDescriptiomDto);
    Task<AppActionResult> GetAllEquipmentActivityPagingAsync(int pageSize, int pageIndex);
    Task<AppActionResult> ChangeEquipmentAsync(int oldEquipmentId, int newEquipmentId, int managerId);
}
