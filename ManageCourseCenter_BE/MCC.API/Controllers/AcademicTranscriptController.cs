using Microsoft.AspNetCore.Mvc;
using MCC.DAL.Service.Interface;
using System.Threading.Tasks;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Dto.AcademicTranscriptDto;

namespace MCC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicTranscriptController : ControllerBase
    {
        private readonly IAcademicTranscriptService _academicTranscriptService;

        public AcademicTranscriptController(IAcademicTranscriptService academicTranscriptService)
        {
            _academicTranscriptService = academicTranscriptService;
        }

        [HttpGet("ByChildrenId")]
        public async Task<IActionResult> GetByChildrenId(int childrenId)
        {
            var result = await _academicTranscriptService.getTranscriptByChildrenIDAsync(childrenId);
            return Ok(result);
        }

        [HttpGet("ByChildrenName")]
        public async Task<IActionResult> GetByChildrenName(string childrenName)
        {
            var result = await _academicTranscriptService.getTranscriptByChildrenNameAsync(childrenName);
            return Ok(result);
        }

        [HttpGet("ByTeacherId")]
        public async Task<IActionResult> GetByTeacherId(int teacherId)
        {
            var result = await _academicTranscriptService.getTranscriptByTeacherIDAsync(teacherId);
            return Ok(result);
        }

        [HttpGet("ByTeacherName")]
        public async Task<IActionResult> GetByTeacherName(string teacherName)
        {
            var result = await _academicTranscriptService.getTranscriptByTeacherNameAsync(teacherName);
            return Ok(result);
        }

        [HttpGet("ByChildrenNameAndCourseName")]
        public async Task<IActionResult> GetByChildrenNameAndCourseName(string childrenName, string courseName)
        {
            var result = await _academicTranscriptService.getTranscriptByChildrenNameAndCourseNameAsync(childrenName, courseName);
            return Ok(result);
        }

        [HttpPost("create-academic-transcript")]
        public async Task<IActionResult> CreateAcademicTranscriptAsync(AcademicTranscriptCreateDto academicTranscriptCreateDto)
        {
            var result = await _academicTranscriptService.CreateAcademicTranscriptAsync(academicTranscriptCreateDto);
            return Ok(result);
        }
    }
}
