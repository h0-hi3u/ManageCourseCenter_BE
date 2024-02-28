using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements;

public class RoomService : IRoomService
{
    private IRoomRepository _roomRepo;

    public RoomService(IRoomRepository roomRepo)
    {
        _roomRepo = roomRepo;
    }

    public async Task<AppActionResult> GetAllRoomAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _roomRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetRoomByFloorAsync(int floor)
    {
        var actionResult = new AppActionResult();
        var data = await _roomRepo.GetRoomByFloorAsync(floor);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetRoomByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _roomRepo.GetByIdAsync(id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetRoomByNoAsync(int no)
    {
        var actionResult = new AppActionResult();
        var data = await _roomRepo.GetRoomByNoAsync(no);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        } else
        {
           return actionResult.BuildError("Not found");
        }
    }
}
