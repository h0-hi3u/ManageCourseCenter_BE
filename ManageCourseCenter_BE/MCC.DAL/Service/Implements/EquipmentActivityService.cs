using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;

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

    public async Task<AppActionResult> CreateEquipmentActivityAsync(EquipmentActivityCreateDto equipActivityCreateDto)
    {
        var actionResult = new AppActionResult();

        try
        {
            var equipActivity = _mapper.Map<EquipmenntActivity>(equipActivityCreateDto);
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
        var data = await _equipmentActivityRepo.GetAllAsync();
        return actionResult.BuildResult(data);
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
}
