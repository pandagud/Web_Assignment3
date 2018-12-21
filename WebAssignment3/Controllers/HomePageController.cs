using System.Linq;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAssignment3.Models.HomePage;

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
            ComponentHandler comphanlder = new ComponentHandler(new bachelordbContext());
            ComponentTypeHandler comptypehanlder = new ComponentTypeHandler(new bachelordbContext());
            CategoryHandler category = new CategoryHandler(new bachelordbContext());
            HomePageModel model = new HomePageModel();
            model.listcategory = category.getAllCategory();
            model.listcomponenttypes = comptypehanlder.GetAlleComponentTypes();
            model.listcomponent = comphanlder.getallComponent();
            model.CategoryComponent = category.GetallCategoryComponentTypes();
            return View(model);
        }

        [Authorize(Policy = "RequiresParticipant")]
        public IActionResult Participant()
        {
            ComponentHandler comphanlder = new ComponentHandler(new bachelordbContext());
            ComponentTypeHandler comptypehanlder = new ComponentTypeHandler(new bachelordbContext());
            CategoryHandler category = new CategoryHandler(new bachelordbContext());
            HomePageModel model = new HomePageModel();
            model.listcategory = category.getAllCategory();
            model.listcomponenttypes = comptypehanlder.GetAlleComponentTypes();
            model.listcomponent = comphanlder.getallComponent();
            model.CategoryComponent = category.GetallCategoryComponentTypes();
            return View(model);
        }
    }
}