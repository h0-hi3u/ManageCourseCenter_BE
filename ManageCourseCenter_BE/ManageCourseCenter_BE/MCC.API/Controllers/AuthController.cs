using MCC.DAL.Authentication;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IChildService _childService;

        public AuthController(IChildService childService)
        {
            _childService = childService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var result = await _childService.Authenticate(model.Username, model.Password);
            if (!result.IsSuccess) return Unauthorized();

            return Ok(result);
        }
    }

}
