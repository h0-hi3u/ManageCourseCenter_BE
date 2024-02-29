using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;

namespace MCC.DAL.Service.Implements;

public class EquipmentActivityService : IEquipmentActivityService
{
    private IEquipmentActivityRepository _equipmentActivityRepo;

    public EquipmentActivityService(IEquipmentActivityRepository equipmentActivityRepo)
    {
        _equipmentActivityRepo = equipmentActivityRepo;
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
