using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAssignment3.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult index()
        {
            if (User.Claims.Count() != 0)
            {
                //Checks if the user is verified as a admin
                if (User.Claims.ElementAt(0).Value == "Y")
                {
                    return RedirectToAction("Admin", "Homepage");
                }
                //Checks if the user is verified as a participant
                if (User.Claims.ElementAt(2).Value == "Y")
                {
                    return RedirectToAction("Participant", "Homepage");
                }
              
            }

            return RedirectToAction("AdminLogin", "Login");
        }

        [Authorize(Policy = "RequiresAdmin")]
        public IActionResult Admin()
        {
            return View();
        }

        [Authorize(Policy = "RequiresParticipant")]
        public IActionResult Participant()
        {
            return View();
        }
    }
}