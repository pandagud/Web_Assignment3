using Microsoft.AspNetCore.Mvc;

namespace WebAssignment3.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }
    }
}