using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto;
using MCC.DAL.Dto.RoomDto;
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
    private IMapper _mapper;

    public RoomService(IRoomRepository roomRepo, IMapper mapper)
    {
        _roomRepo = roomRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> CreateRoomAsync(RoomCreateDto roomCreateDto)
    {
        var actionResult = new AppActionResult();
        var checkRoomNo = await _roomRepo.CheckExistingRoomNoAsync(roomCreateDto.RoomNo);
        if (!checkRoomNo)
        {
            return actionResult.BuildError("Duplicate room no");
        }
        try
        {
            var room = _mapper.Map<Room>(roomCreateDto);
            await _roomRepo.AddAsync(room);
            await _roomRepo.SaveChangesAsync();
            return actionResult.BuildResult("Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
    }

    public async Task<AppActionResult> GetAllRoomAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _roomRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetAllRoomPagingAsync(int pageSize, int pageIndex)
    {
        var actionResult = new AppActionResult();
        PagingDto pagingDto = new PagingDto();
        var skip = CalculateHelper.CalculatePaging(pageSize, pageIndex);
        List<Room> listRoom = new List<Room>();

        var data = await _roomRepo.GetAllAsync();
        listRoom.AddRange(data);

        var totalRecords = listRoom.Count;
        var result = listRoom.Skip(skip).Take(pageSize).ToList();

        pagingDto.Data = result;
        pagingDto.TotalRecords = totalRecords;
        return actionResult.BuildResult(pagingDto);
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
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> UpdateRoomAsync(int roomId, RoomUpdateDto roomUpdateDto)
    {
        var actionResult = new AppActionResult();

        var room = await _roomRepo.GetByIdAsync(roomId);
        if (room == null)
        {
            return actionResult.BuildError("Room not found.");
        }

        if (room.RoomNo != roomUpdateDto.RoomNo && !(await _roomRepo.IsRoomNoUniqueAsync(roomUpdateDto.RoomNo, roomId)))
        {
            return actionResult.BuildError("Duplicate room no");
        }

        try
        {
            _mapper.Map(roomUpdateDto, room);

            await _roomRepo.UpdateRoomAsync(room);
            return actionResult.BuildResult("Update success");
        }
        catch (Exception ex)
        {
            return actionResult.BuildError($"Update fail: {ex.Message}");
        }
    }

    public async Task<AppActionResult> UpdateRoomStatusAsync(RoomStatusUpdateDto updateDto)
    {
        var actionResult = new AppActionResult();

        var room = await _roomRepo.GetByIdAsync(updateDto.Id);
        if (room == null)
        {
            return actionResult.BuildError("Room not found.");
        }

        _mapper.Map(updateDto, room);

        try
        {
            await _roomRepo.UpdateRoomAsync(room);
            return actionResult.BuildResult("Status update success");
        }
        catch (Exception ex)
        {
            return actionResult.BuildError($"Status update fail: {ex.Message}");
        }
    }

    public async Task<AppActionResult> GetRoomIdByActivityIdAsync(int activityId)
    {
        var actionResult = new AppActionResult();
        var roomId = await _roomRepo.GetRoomIdByActivityIdAsync(activityId);

        if (roomId.HasValue)
        {
            actionResult.IsSuccess = true;
            actionResult.Data = roomId.Value;
            actionResult.Detail = "Room ID fetched successfully.";
        }
        else
        {
            actionResult.IsSuccess = false;
            actionResult.Detail = "Activity or Room not found.";
        }
        return actionResult;
    }

}
