using MCC.DAL.Common;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChildController : ControllerBase
{
    private IChildService _childService;

    public ChildController(IChildService childService)
    {
        _childService = childService;
    }
    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _childService.GetAllChildAsync();
        return Ok(result);
    }
    [HttpGet("get-by-name")]
    public async Task<IActionResult> GetByNameAsync(string name)
    {
        var result = await _childService.GetChildByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-by-id")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _childService.GetChildByIdAsync(id);
        return Ok(result);
    }
    [HttpPost("create-child")]
    public async Task<IActionResult> CreateChildAsync(ChildCreatDto childCreatDto)
    {
        var result = await _childService.CreateChildAsync(childCreatDto);
        return Ok(result);
    }
    [HttpPut("update-child")]
    public async Task<IActionResult> UpdateChildAsync(ChildUpdateDto childUpdateDto)
    {
        var result = await _childService.UpdateChildAsync(childUpdateDto);
        return Ok(result);
    }
    [HttpGet("get-child-username-password")]
    public async Task<IActionResult> GetChildrenByUsernameAndPassword(string username, string password)
    {
        var result = await _childService.GetChildrenByUsernameAndPasswordAsync(username, password);
        return Ok(result);
    }
    [HttpGet("cout-number-childrent")]
    public async Task<IActionResult> CountNumberChildrentAsync()
    {
        var count = await _childService.CountNumberChildrent();
        return Ok(count);
    }
    [HttpGet("get-all-child-paging")]
    public async Task<IActionResult> GetAllChildPagingAsync(int pageSize, int pageIndex)
    {
        var result = await _childService.GetAllChildPagingAsync(pageSize, pageIndex);
        return Ok(result);
    }
    [HttpPost("create-child-with-parentId")]
    public async Task<IActionResult> CreateChildrenWithParentID(int parentId, [FromBody] ChildCreatDto childCreateDto)
    {
        var result = await _childService.CreateChildrenWithParentID(parentId, childCreateDto);
        return Ok(result);
    }
    [HttpGet("get-all-children-by-parentId")]
    public async Task<IActionResult> GetAllChildrenByParentIdAsync(int parentId, int pageIndex = 1, int pageSize = 5)
    {
        var result = await _childService.GetAllChildrenByParentId(parentId, pageIndex, pageSize);
        return Ok(result);
    }
    [HttpPut("update-children/{parentId}")]
    public async Task<IActionResult> UpdateChildrenOfAParent(int parentId, [FromBody] List<ChildUpdateDto> childUpdates)
    {
        if (childUpdates == null || !childUpdates.Any())
        {
            return BadRequest("Invalid child update data.");
        }

        var result = await _childService.UpdateChildrenOfAParent(parentId, childUpdates);
        return Ok(result);

    }
    [HttpGet("get-all-child-by-class-id")]
    public async Task<IActionResult> GetAllChildByClassId(int classId)
    {
        var result = await _childService.GetAllChildByClassId(classId);
        return Ok(result);
    }

    [HttpGet("get-list-child-not-enrolled")]
    public async Task<IActionResult> GetChildrenListNotEnrollCourseAsync(int parentId, int courseId, int pageSize, int pageIndex)
    {
        var result = await _childService.GetChildrenListNotEnrollCourseAsync(parentId, courseId, pageSize, pageIndex);
        return Ok(result);
    }
}
