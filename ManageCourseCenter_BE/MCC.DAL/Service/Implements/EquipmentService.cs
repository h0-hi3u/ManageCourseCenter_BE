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
    public class EquipmentService : IEquipmentService
    {
        private IEquipmentRepository _equipRepo;
        private IMapper _mapper;

        public EquipmentService(IEquipmentRepository equipRepo, IMapper mapper)
        {
            _equipRepo = equipRepo;
            _mapper = mapper;
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
    }
}
