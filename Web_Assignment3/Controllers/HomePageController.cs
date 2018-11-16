using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web_Assignment3.Controllers
{
    public class HomePageController : Controller
    {
        //[Authorize(Policy = "RequiresAdmin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}