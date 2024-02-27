using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private IClassService _classService;

    public ClassController(IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _classService.GetAllClassAsync();
        return Ok(result);
    }
    [HttpGet("get-class-courseId")]
    public async Task<IActionResult> GetClassByCourseIdAsync(int courseId)
    {
        var result = await _classService.GetClassByCourseIdAsync(courseId);
        return Ok(result);
    }
    [HttpGet("get-class-courseName")]
    public async Task<IActionResult> GetClassByCourseNameAsync(string courseName)
    {
        var result = await _classService.GetClassByNameAsync(courseName);
        return Ok(result);
    }
    [HttpGet("get-class-id")]
    public async Task<IActionResult> GetClassByIdAsync(int id)
    {
        var result = await _classService.GetClassByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-class-name")]
    public async Task<IActionResult> GetClassByNameAsync(string name)
    {
        var result = await _classService.GetClassByNameAsync(name);
        return Ok(result);
    }
}
