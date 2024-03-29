﻿using MCC.DAL.Common;
using MCC.DAL.Dto.ChildrenClassDto;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenClassController : ControllerBase
    {
        private readonly IChildrenClassService _childrenClassService;

        public ChildrenClassController(IChildrenClassService childrenClassService)
        {
            _childrenClassService = childrenClassService;
        }

        [HttpGet("get-by-childrenId")]
        public async Task<IActionResult> GetChildrenClassByChildrenID(int childrenId)
        {
            var result = await _childrenClassService.GetChildrenClassByChildrenIDAsync(childrenId);
            return Ok(result);
        }

        [HttpGet("get-by-childrenName")]
        public async Task<IActionResult> GetChildrensClassByChildrenName(string childrenName)
        {
            var result = await _childrenClassService.GetChildrensClassByChildrenNameAsync(childrenName);
            return Ok(result);
        }

        [HttpGet("get-by-classId")]
        public async Task<IActionResult> GetChildrenClassByClassID(int classId)
        {
            var result = await _childrenClassService.GetChildrenClassByClassIDAsync(classId);
            return Ok(result);
        }

        [HttpGet("get-by-className")]
        public async Task<IActionResult> GetChildrenClassByClassName(string className)
        {
            var result = await _childrenClassService.GetChildrenClassByClassNameAsync(className);
            return Ok(result);
        }

        [HttpPost("create-children-class")]
        public async Task<IActionResult> CreateChildrenClassAsync(ChildrenClassCreateDto childrenClassCreateDto)
        {
            var result = await _childrenClassService.CreateChildClassAsync(childrenClassCreateDto);
            return Ok(result);
        }

        [HttpDelete("delete-children-class")]
        public async Task<IActionResult> DeleteChildrenClass(int childrenClassId)
        {
            var result = await _childrenClassService.DeleteChildrenClassAsync(childrenClassId);
            return Ok(result);
        }

        [HttpGet("get-children-class-Id-by-childId-and-classId")]
        public async Task<IActionResult> GetChildrenClassIdByChildIdAndClassByIdAsync(int childId, int classId)
        {
            var result = await _childrenClassService.GetChildrenClassIdByChildIdAndClassByIdAsync(childId, classId);
            return Ok(result);
        }
    }
}
