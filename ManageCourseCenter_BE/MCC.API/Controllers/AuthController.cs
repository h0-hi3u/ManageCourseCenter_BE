using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
