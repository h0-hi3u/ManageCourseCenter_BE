using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
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
    public class EquipmentService : IEquipmentService
    {
        private IEquipmentRepository _equipRepo;
        private IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipRepo, IMapper mapper)
        {
            _equipRepo = equipRepo;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateEquipmentAsync(EquipmentCreateDto equipmentCreateDto)
        {
            var actionResult = new AppActionResult();

            var checkName = await _equipRepo.CheckExistingNameAsync(equipmentCreateDto.Name);
            if (!checkName)
            {
                return actionResult.BuildError("Duplicate name");
            }

            try
            {
                var equip = _mapper.Map<Equipment>(equipmentCreateDto);
                await _equipRepo.AddAsync(equip);
                await _equipRepo.SaveChangesAsync();
                return actionResult.SetInfo(true, "Add success");
            }
            catch
            {
                return actionResult.BuildError("Add fail");
            }
        }

        public async Task<AppActionResult> GetAllEquipmentAsync()
        {
            var actionResult = new AppActionResult();
            var data = await _equipRepo.GetAllAsync();
            return actionResult.BuildResult(data);
        }

        public async Task<AppActionResult> GetEquipmentByIdAsync(int id)
        {
            var actionResult = new AppActionResult();
            var data = await _equipRepo.GetByIdAsync(id);
            if(data != null)
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> GetEquipmentByNameAsync(string name)
        {
            var actionResult = new AppActionResult();
            var data = await _equipRepo.Entities().Where(e => e.Name.Contains(name)).ToListAsync();
            return actionResult.BuildResult(data);        }

        public async Task<AppActionResult> GetEquipmentByTypeAsync(int type)
        {
            var actionResult = new AppActionResult();
            var data = await _equipRepo.Entities().Where(e => e.Type.Equals(type)).ToListAsync();
            if(data != null)
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> UpdateEquipmentAsync(int equipmentId, EquipmentUpdateDto equipmentUpdateDto)
        {
            var actionResult = new AppActionResult();

            var equipment = await _equipRepo.GetByIdAsync(equipmentId);
            if (equipment == null)
            {
                return actionResult.BuildError("Equipment not found.");
            }

            if (!string.IsNullOrEmpty(equipmentUpdateDto.Name) &&
                equipment.Name != equipmentUpdateDto.Name &&
                !(await _equipRepo.IsNameUniqueAsync(equipmentUpdateDto.Name, equipmentId)))
            {
                return actionResult.BuildError("Equipment name already in use.");
            }

            _mapper.Map(equipmentUpdateDto, equipment);

            var success = await _equipRepo.UpdateEquipmentAsync(equipment);
            if (!success)
            {
                return actionResult.BuildError("Failed to update equipment.");
            }
            return actionResult.BuildResult("Equipment updated successfully.");
        }
    }
}
