using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class EquipmentReportService : IEquipmentReportService
    {
        private IEquipmentReportRepository _equiprpRepo;
        private IMapper _mapper;

        public EquipmentReportService(IEquipmentReportRepository equiprpRepo, IMapper mapper)
        {
            _equiprpRepo = equiprpRepo;
            _mapper = mapper;
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
            if(data != null)
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
            if(data != null)
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

        public async Task<AppActionResult> GetReptortByTeacherIdAsync(int teacherId, int pageSize, int pageIndex)
        {
            var actionResult = new AppActionResult();
            PagingDto pagingDto = new PagingDto();

            var totalRecords = await _equiprpRepo.Entities().Where(r => r.SenderId == teacherId).CountAsync();
            int skip = CalculateHelper.CalculatePazing(pageSize, pageIndex);
            var result = await _equiprpRepo.Entities()
                    .Include(r => r.Equipment)
                    .Include(r => r.Room)
                    .Where(r => r.SenderId == teacherId)
                    .OrderByDescending(r => r.SendTime)
                    .Skip(skip)
                    .Take(pageSize)
                    .ToListAsync();
            pagingDto.TotalRecords = totalRecords;
            pagingDto.Data = result;
            return actionResult.BuildResult(pagingDto);

        }
    }
}
