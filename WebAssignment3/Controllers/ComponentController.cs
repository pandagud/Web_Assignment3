using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.Component;

namespace WebAssignment3.Controllers
{
    public class ComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewCreateComponent()
        {
            return View();
        }

        public IActionResult CreateComponent(Component model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "HomePage");
            }

            return ViewCreateComponent();
        }
    }
}