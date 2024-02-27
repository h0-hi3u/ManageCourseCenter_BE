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
    }
}
