using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Constants;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.PaymentDto;
using MCC.DAL.Dto.RoomDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCC.DAL.Service.Implements.ParentService;

namespace MCC.DAL.Service.Implements
{
    public class EquipmentReportService : IEquipmentReportService
    {
        private IEquipmentReportRepository _equiprpRepo;
        private IMapper _mapper;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IRoomRepository _roomRepository;

        public EquipmentReportService(IEquipmentReportRepository equiprpRepo, IMapper mapper, IEquipmentRepository equipmentRepository, IRoomRepository roomRepository)
        {
            _equiprpRepo = equiprpRepo;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
            _roomRepository = roomRepository;
        }

        public async Task<AppActionResult> GetAllEquipmentReportAsync()
        {
            var actionReult = new AppActionResult();
            var data = await _equiprpRepo.Entities().Include(er => er.Equipment).Include(er =>  er.Equipment.EquipmentActivities).ToListAsync();
            return actionReult.BuildResult(data);
        }

        public async Task<AppActionResult> GetEquipmentReportByIdAsync(int id)
        {
            var actionReult = new AppActionResult();
            var data = await _equiprpRepo.GetByIdAsync(id);
            if (data != null)
            {
                return actionReult.BuildResult(data);
            }
            else
            {
                return actionReult.BuildError("Not found");
            }
        }
        public async Task<AppActionResult> GetEquipmentReportByEquipmentIdAsync(int equipmentid)
        {
            var actionReult = new AppActionResult();
            var data = await _equiprpRepo.Entities().Include(e => e.Equipment).SingleOrDefaultAsync(e => e.Id == equipmentid);
            if (data != null)
            {
                return actionReult.BuildResult(data.Equipment);
            }
            else
            {
                return actionReult.BuildError("Not found");
            }
        }
        public async Task<AppActionResult> GetEquipmentReportByRoomIdAsync(int roomid)
        {
            var actionReult = new AppActionResult();
            var data = await _equiprpRepo.Entities().Include(e => e.Room).SingleOrDefaultAsync(e => e.Id == roomid);
            if (data != null)
            {
                return actionReult.BuildResult(data.Room);
            }
            else
            {
                return actionReult.BuildError("Not found");
            }
        }
        public async Task<AppActionResult> GetEquipmentReportByRoomNoAsync(int roomno)
        {
            var actionReult = new AppActionResult();
            var data = await _equiprpRepo.Entities().Include(e => e.Room).SingleOrDefaultAsync(e => e.Room.RoomNo == roomno);
            if (data != null)
            {
                return actionReult.BuildResult(data.Room);
            }
            else
            {
                return actionReult.BuildError("Not found");
            }
        }
        public async Task<AppActionResult> GetEquipmentReportByEquipmentNameAsync(string equipmentname)
        {
            var actionResult = new AppActionResult();
            var data = await _equiprpRepo.Entities().Include(e => e.Equipment).SingleOrDefaultAsync(e => e.Equipment.Name == equipmentname);
            if (data != null)
            {
                return actionResult.BuildResult(data.Equipment);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> CreateEquipmentReportAsync(EquipmentReportCreateDto equipmentReportCreateDto)
        {
            var actionResult = new AppActionResult();

            try
            {
                var equipReport = _mapper.Map<EquipmentReport>(equipmentReportCreateDto);
                await _equiprpRepo.AddAsync(equipReport);
                await _equiprpRepo.SaveChangesAsync();
                return actionResult.SetInfo(true, "Add success");
            }
            catch
            {
                return actionResult.BuildError("Add fail");
            }
        }

        public enum EquipmentRepostStatus
        {
            OPENING = 1,
            CLOSED = 2,
            DELETED = 3
        }

        public async Task<AppActionResult> UpdateEquipmentReportAsync(int equipmentReportId, EquipmentReportUpdateDto equipmentReportUpdateDto)
        {
            var actionResult = new AppActionResult();

            var equipmentReport = await _equiprpRepo.GetByIdAsync(equipmentReportId);
            if (equipmentReport == null)
            {
                return actionResult.BuildError("Equipment Report not found.");
            }

            // check when change EquipmentId
            if (equipmentReport.EquipmentId != equipmentReportUpdateDto.EquipmentId)
            {
                var equipment = await _equipmentRepository.GetByIdAsync(equipmentReportUpdateDto.EquipmentId);
                if (equipment == null)
                {
                    return actionResult.BuildError("Equipment not found.");
                }

                var isUsedInOtherOpeningReport = await _equiprpRepo.Entities().AnyAsync(er =>
                    er.Id != equipmentReportId &&
                    er.EquipmentId == equipmentReportUpdateDto.EquipmentId &&
                    er.Status == equipmentReportUpdateDto.Status);

                if (isUsedInOtherOpeningReport)
                {
                    return actionResult.BuildError("This equipment is currently being used in another opening report and cannot be updated.");
                }
            }

            var room = await _roomRepository.GetByIdAsync(equipmentReportUpdateDto.RoomId);
            if (room == null)
            {
                return actionResult.BuildError("Room not found.");
            }

            // check when change status
            if (equipmentReportUpdateDto.Status == CoreConstants.STT_EQUIPMENT_REPORT_OPENING)
            {
                var isUsedInOtherOpeningReport = await _equiprpRepo.Entities().AnyAsync(er =>
                    er.Id != equipmentReportId &&
                    er.EquipmentId == equipmentReportUpdateDto.EquipmentId &&
                    er.Status == CoreConstants.STT_EQUIPMENT_REPORT_OPENING);

                if (isUsedInOtherOpeningReport)
                {
                    return actionResult.BuildError("Another report is already opening with this equipment.");
                }
            }

            if (equipmentReportUpdateDto.Status != default && !Enum.IsDefined(typeof(EquipmentRepostStatus), equipmentReportUpdateDto.Status))
            {
                return actionResult.BuildError("Invalid equipment report status");
            }

            try
            {
                if (equipmentReportUpdateDto.Status != default)
                {
                    equipmentReport.Status = equipmentReportUpdateDto.Status;
                }
                equipmentReport.Description = equipmentReportUpdateDto.Description;
                equipmentReport.RoomId = room.Id;
                equipmentReport.EquipmentId = equipmentReportUpdateDto.EquipmentId;

                await _equiprpRepo.SaveChangesAsync();
                return actionResult.BuildResult("Update success");
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"Update fail: {ex.Message}");
            }
        }
    }
}
