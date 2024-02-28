using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface IScheduleService
    {
        public Task<AppActionResult> GetScheduleByRoomNo(int roomNo);
        public Task<AppActionResult> GetScheduleByTeacherId(int teacherId);
        public Task<AppActionResult> GetScheduleByChildrenClassId(int childerClassId);
        public Task<AppActionResult> GetScheduleByRoomId(int roomId);
        public Task<AppActionResult> GetAllSchedule();
    }
}
