using MCC.DAL.Dto.TeacherDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllTeacherAsync()
    {
        var result = await _teacherService.GetAllTeacherAsync();
        return Ok(result);
    }
    [HttpGet("get-teacher-id")]
    public async Task<IActionResult> GetTeachByIdAsync(int id)
    {
        var result = await _teacherService.GetTeachByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-teacher-name")]
    public async Task<IActionResult> GetTeacherByNameAsync(string name)
    {
        var result = await _teacherService.GetTeachByNameAsync(name);
        return Ok(result);
    }
    [HttpPost("creat-teacher")]
    public async Task<IActionResult> CreateTeacherAsync(TeacherCreateDto teacherCreateDto)
    {
        var result = await _teacherService.CreateTeacherAsync(teacherCreateDto);
        return Ok(result);
    }
    [HttpGet("get-teacher-email-password")]
    public async Task<IActionResult> GetTeacherByEmailAndPasswordAsync(string email, string password)
    {
        var result = await _teacherService.GetTeacherByEmailAndPasswordAsync(email, password);
        return Ok(result);
    }
}
