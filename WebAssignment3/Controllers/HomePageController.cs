using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAssignment3.Controllers
{
    public class HomePageController : Controller
    {
        [Authorize(Policy = "RequiresAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}