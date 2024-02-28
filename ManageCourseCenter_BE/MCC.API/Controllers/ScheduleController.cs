using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("get-schedule_by_room_no")]
        public async Task<IActionResult> GetScheduleByRoomNo(int roomNo)
        {
            var result = await _scheduleService.GetScheduleByRoomNo(roomNo);
            return Ok(result);
        }

        [HttpGet("get-schedule_by_children_class_id")]
        public async Task<IActionResult> GetScheduleByChildrenClassId(int roomNo)
        {
            var result = await _scheduleService.GetScheduleByChildrenClassId(roomNo);
            return Ok(result);
        }

        [HttpGet("get-schedule_by_room_id")]
        public async Task<IActionResult> GetScheduleByRoomId(int roomNo)
        {
            var result = await _scheduleService.GetScheduleByRoomId(roomNo);
            return Ok(result);
        }

        [HttpGet("get-schedule_by_teacher-id")]
        public async Task<IActionResult> GetScheduleByTeacherId(int roomNo)
        {
            var result = await _scheduleService.GetScheduleByTeacherId(roomNo);
            return Ok(result);
        }

        [HttpGet("get-all-schedule")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var result = await _scheduleService.GetAllSchedule();
            return Ok(result);
        }
    }
}
