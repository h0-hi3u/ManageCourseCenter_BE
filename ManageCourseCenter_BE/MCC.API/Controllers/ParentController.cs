using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParentController : ControllerBase
{
    private IParentService _parentService;

    public ParentController(IParentService parentService)
    {
        _parentService = parentService;
    }
    [HttpGet("get-all-parent")]
    public async Task<IActionResult> GetAllParentAsync()
    {
        var result = await _parentService.GetAllParentAsync();
        return Ok(result);
    }
    [HttpGet("get-parent-id")]
    public async Task<IActionResult> GetParentById(int id)
    {
        var result = await _parentService.GetParentByIdAsync(id);
        return Ok(result);
    }
    [HttpGet("get-parent-name")]
    public async Task<IActionResult> GetParentByName(string name)
    {
        var result = await _parentService.GetParentByNameAsync(name);
        return Ok(result);
    }
    [HttpGet("get-child-parentId")]
    public async Task<IActionResult> GetChildWithParentIdAsync(int id)
    {
        var result = await _parentService.GetChildWithParentId(id);
        return Ok(result);
    }
    [HttpGet("get-child-email")]
    public async Task<IActionResult> GetChildWithParentEmailAsync(string email)
    {
        var result = await _parentService.GetChildWithParentEmail(email);
        return Ok(result);
    }
    [HttpPost("create-parent")]
    public async Task<IActionResult> CreateParentAsync(ParentCreateDto parentCreateDto)
    {
        var result = await _parentService.CreateParentAsync(parentCreateDto);
        return Ok(result);
    }
    [HttpGet("get-parent-email-password")]
    public async Task<IActionResult> GetParentByEmailAndPasswordAsync(string email, string password)
    {
        var result = await _parentService.GetParentByEmailAndPasswordAsync(email, password);
        return Ok(result);
    } 
    
    [HttpPut("update-parent-information")]
    public async Task<IActionResult> UpdateParentInformationAsync(ParentUpdateDto parentUpdateDto)
    {
        var result = await _parentService.UpdateParentInformationAsync(parentUpdateDto);
        return Ok(result);
    }
    [HttpGet("count-number-parent")]
    public async Task<IActionResult> CountNumberParent()
    {
        var count = await _parentService.CountNumberParent();
        return Ok(count);
    }
/*    [HttpGet("get-all-children-by-parentId")]
    public async Task<IActionResult> GetAllChildrenByParentIdAsync(int parentId, int pageIndex = 1, int pageSize = 5)
    {
        var result = await _parentService.GetAllChildrenByParentId(parentId, pageIndex, pageSize);
        return Ok(result);
    }*/
/*    [HttpPost("create-child-with-parentId")]
    public async Task<IActionResult> CreateChildrenWithParentID(int parentId, [FromBody] ChildCreatDto childCreateDto)
    {
        var result = await _parentService.CreateChildrenWithParentID(parentId, childCreateDto);
        return Ok(result);
    }*/

/*    [HttpPut("update-children/{parentId}")]
    public async Task<IActionResult> UpdateChildrenOfAParent(int parentId, [FromBody] List<ChildUpdateDto> childUpdates)
    {
        if (childUpdates == null || !childUpdates.Any())
        {
            return BadRequest("Invalid child update data.");
        }

        var result = await _parentService.UpdateChildrenOfAParent(parentId, childUpdates);
        return Ok(result);
        
    }*/

}
