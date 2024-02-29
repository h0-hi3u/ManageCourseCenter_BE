using AutoMapper;
using MCC.DAL.Common;
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
            var data = await _equiprpRepo.GetAllAsync();
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
    }
}
