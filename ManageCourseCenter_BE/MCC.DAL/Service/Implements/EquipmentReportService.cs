using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
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
    }
}
