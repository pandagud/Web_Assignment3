using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Category = WebAssignment3.Models.Category.Category;

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
                CategoryHandler handler = new CategoryHandler(new bachelordbContext());
                BackEnd.Models.Category dbcat  =new BackEnd.Models.Category();
                dbcat.Name = model.Name;
                handler.AddCategory(dbcat);
                return RedirectToAction("Index", "HomePage");
            }

            return ViewCategoryType();
        }
    }
}