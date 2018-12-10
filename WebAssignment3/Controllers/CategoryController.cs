using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.Category;

namespace WebAssignment3.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ViewCategoryType()
        {
            return View();
        }

        public IActionResult CreateComponentType(Category model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "HomePage");
            }

            return ViewCategoryType();
        }
    }
}