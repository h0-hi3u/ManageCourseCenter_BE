using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using static MCC.DAL.Service.Implements.CartService;

namespace MCC.DAL.Service.Implements;

public class EquipmentActivityService : IEquipmentActivityService
{
    private IEquipmentActivityRepository _equipmentActivityRepo;
    private IMapper _mapper;

    public EquipmentActivityService(IEquipmentActivityRepository equipmentActivityRepo, IMapper mapper)
    {
        _equipmentActivityRepo = equipmentActivityRepo;
        _mapper = mapper;
    }

    public Task<AppActionResult> ChangeEquipmentAsync(int oldEquipmentId, int newEquipmentId)
    {
        throw new NotImplementedException();
    }

    public async Task<AppActionResult> CreateEquipmentActivityAsync(EquipmentActivityCreateDto equipActivityCreateDto)
    {
        var actionResult = new AppActionResult();

        try
        {
            var equipActivity = _mapper.Map<EquipmentActivity>(equipActivityCreateDto);
            await _equipmentActivityRepo.AddAsync(equipActivity);
            await _equipmentActivityRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
    }

    public async Task<AppActionResult> GetAllEquipmentActivityAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.Entities().Include(ea => ea.Manager).Include(ea => ea.Room).Include(ea => ea.Equipment).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetAllEquipmentActivityPagingAsync(int pageSize, int pageIndex)
    {
        var actionResult = new AppActionResult();
        PagingDto pagingDto = new PagingDto();
        var skip = CalculateHelper.CalculatePaging(pageSize, pageIndex);

        var totalRecords = await _equipmentActivityRepo.Entities().Include(ea => ea.Manager).Include(ea => ea.Room).Include(ea => ea.Equipment).ToListAsync();
        var data = await _equipmentActivityRepo.Entities().Include(ea => ea.Manager).Include(ea => ea.Room).Include(ea => ea.Equipment).Skip(skip).Take(pageSize).ToListAsync();

        pagingDto.TotalRecords = totalRecords.Count;
        pagingDto.Data = data;
        return actionResult.BuildResult(pagingDto);
    }

    public async Task<AppActionResult> GetEquipmentByEquipmentId(int equipmentId)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetActivitiesByEquipmentIdAsync(equipmentId);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetEquipmentByManagerId(int managerId)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetActivitiesByManagerIdAsync(managerId);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetEquipmentByRoomId(int roomId)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetActivitiesByRoomIdAsync(roomId);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetEquipmentByRoomNo(int roomNo)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetActivitiesByRoomNoAsync(roomNo);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetEquipmentByTimeRange(DateTime from, DateTime to)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetActivitiesByTimeRangeAsync(from, to);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetLatestActivityByEquipmentId(int equipmentId)
    {
        var actionResult = new AppActionResult();
        var data = await _equipmentActivityRepo.GetLatestActivityByEquipmentId(equipmentId);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> UpdateEquipmentActivityDescriptionAsync(EquipmentActivityUpdateDescriptiomDto equipmentActivityUpdateDescriptiomDto)
    {
        var actionResult = new AppActionResult();

        try
        {
            var equipmentActivity = await _equipmentActivityRepo.GetByIdAsync(equipmentActivityUpdateDescriptiomDto.Id);
            if (equipmentActivity == null)
            {
                return actionResult.BuildError("Equipment Activity not found");
            }

            equipmentActivity.Description = equipmentActivityUpdateDescriptiomDto.Description;
            await _equipmentActivityRepo.SaveChangesAsync();

            return actionResult.SetInfo(true, "Update success");
        }
        catch
        {
            return actionResult.BuildError("Update fail");
        }
    }

    public async Task<AppActionResult> UpdateEquipmentActivityFinishedTimeAsync(int id)
    {
        var actionResult = new AppActionResult();
        var equipmentActivity = await _equipmentActivityRepo.GetByIdAsync(id);

        if (equipmentActivity == null)
        {
            return actionResult.BuildError("Equipment activity not found.");
        }

        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

        var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneInfo);

        equipmentActivity.FinishedTime = localTime;

        var updateSuccess = await _equipmentActivityRepo.UpdateAsync(equipmentActivity);

        if (!updateSuccess)
        {
            return actionResult.BuildError("Failed to update the finished time.");
        }

        return actionResult.BuildResult("Finished time updated successfully.");
    }
}
