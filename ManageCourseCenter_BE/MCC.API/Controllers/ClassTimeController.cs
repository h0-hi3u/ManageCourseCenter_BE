using MCC.DAL.Dto.ClassTimeDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassTimeController : ControllerBase
{
    private IClassTimeService _classTimeService;

    public ClassTimeController(IClassTimeService classTimeService)
    {
        _classTimeService = classTimeService;
    }
    [HttpGet("get-classTime-classId")]
    public async Task<IActionResult> GetClassTimeByClassIdAsync(int classId)
    {
        var result = await _classTimeService.GetClassTimeByClassIdAsync(classId);
        return Ok(result);
    }
    [HttpGet("get-classTime-className")]
    public async Task<IActionResult> GetClassTimeByClassNameAsync(string className)
    {
        var result = await _classTimeService.GetClassTimeByClassName(className);
        return Ok(result);
    }
    [HttpPost("create-class-time")]
    public async Task<IActionResult> CreateClassTimeAsync(ClassTimeCreateDto classTimeCreateDto)
    {
        var result = await _classTimeService.CreateClassTimeAsync(classTimeCreateDto);
        return Ok(result);
    }
}
