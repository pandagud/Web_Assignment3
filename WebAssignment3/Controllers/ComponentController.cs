using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Component = WebAssignment3.Models.Component.Component;

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
           
                BackEnd.Models.Component component = new BackEnd.Models.Component();
                component.AdminComment = model.AdminComment;
                component.ComponentNumber = model.ComponentNumber;
                component.SerialNo = model.SerialNo;
                component.UserComment = model.UserComment;
                component.Status = model.Status.ToString();
                component.CurrentLoanInformationId = Convert.ToInt64(User.Claims.ElementAt(3).Value);
                ComponentHandler handler = new ComponentHandler(new bachelordbContext());
                handler.saveComponent(component);
                return RedirectToAction("Index", "HomePage");
        
        }
    }
}