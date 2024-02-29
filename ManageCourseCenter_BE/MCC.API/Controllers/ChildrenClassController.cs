using MCC.DAL.Common;
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
    }
}
