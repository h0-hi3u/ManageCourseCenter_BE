using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<AppActionResult> GetAllSchedule()
        {
            var actionResult = new AppActionResult();
            var data = await _scheduleRepository.GetAllAsync();
            return actionResult.BuildResult(data);
        }

        public async Task<AppActionResult> GetScheduleByChildrenClassId(int childerClassId)
        {
            var actionResult = new AppActionResult();
            var data = await _scheduleRepository.GetScheduleByChildrenClassId(childerClassId);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> GetScheduleByRoomId(int roomId)
        {
            var actionResult = new AppActionResult();
            var data = await _scheduleRepository.GetScheduleByRoomId(roomId);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> GetScheduleByRoomNo(int roomNo)
        {
            var actionResult = new AppActionResult();
            var data = await _scheduleRepository.GetScheduleByRoomNo(roomNo);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> GetScheduleByTeacherId(int roomNo)
        {
            var actionResult = new AppActionResult();
            var data = await _scheduleRepository.GetScheduleByTeacherId(roomNo);
            if (data.Any())
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
