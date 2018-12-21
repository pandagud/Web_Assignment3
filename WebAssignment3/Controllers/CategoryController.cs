using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Category = WebAssignment3.Models.Category.Category;

namespace WebAssignment3.Controllers
{
    [Authorize(Policy = "RequiresAdmin")]
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

        public IActionResult CreateCategoryType(Category model)
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

        public IActionResult ViewDeleteCategory()
        {
            return View();
        }

        public IActionResult DeleteCategory(Category model)
        {
            BackEnd.Models.Category category = new BackEnd.Models.Category();
            category.CategoryId = model.CategoryId;
            CategoryHandler handler = new CategoryHandler(new bachelordbContext());
            handler.DeleteCateogry(category);
            return RedirectToAction("Index", "HomePage");
        }

        public IActionResult ViewUpdateCategory()
        {
            return View();
        }

        public IActionResult UpdateCategory(Category model)
        {
            BackEnd.Models.Category category = new BackEnd.Models.Category();
            category.CategoryId = model.CategoryId;
            CategoryHandler handler = new CategoryHandler(new bachelordbContext());
            var newcat = handler.getComponent(category);
            if (newcat.Name != null)
            {
                newcat.Name = model.Name;
              
                handler.UpdateCategory(newcat);

                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                this.ModelState.AddModelError("Name", "There is no component with that ID");
                return View("ViewUpdateCategory");
            }
        }
    }
}