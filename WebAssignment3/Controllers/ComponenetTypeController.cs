using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.Component;

namespace WebAssignment3.Controllers
{
    public class ComponenetTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCreateComponentType()
        {
            return View();
        }

        public IActionResult CreateComponentType(ComponentType model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "HomePage");
            }

            return ViewCreateComponentType();
        }
    }
}