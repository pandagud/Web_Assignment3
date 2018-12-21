using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Handlers;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ComponentType = WebAssignment3.Models.Component.ComponentType;

namespace WebAssignment3.Controllers
{
    [Authorize(Policy = "RequiresAdmin")]
    public class ComponenetTypeController : Controller
    {
        public IActionResult ViewCreateComponentType()
        {
            CategoryHandler cathandler = new CategoryHandler(new bachelordbContext());
            var listcat = cathandler.getAllCategory();
            var model = new ComponentType();
            model.cateList = new List<SelectListItem>();
            model.cateList.Add(new SelectListItem
            {
                Text = "empty",Value="Emptyval"
            });
            foreach (var x in listcat)
            {
                model.cateList.Add(new SelectListItem
                {
                    Text=x.Name,Value=x.CategoryId.ToString()
                });
            }
            model.Categories = listcat;
           return View(model);
        }

        public IActionResult CreateComponentType(ComponentType model)
        {
          
                ComponentTypeHandler handler = new ComponentTypeHandler(new bachelordbContext());
                BackEnd.Models.ComponentType dbcat = new BackEnd.Models.ComponentType();
                dbcat.AdminComment = model.AdminComment;
                dbcat.ComponentInfo = model.ComponentInfo;
                dbcat.ComponentName = model.ComponentName;
               //dbcat.ComponentTypeStatus
                dbcat.Datasheet = model.Datasheet;
                dbcat.ImageUrl = model.ImageUrl;
                dbcat.Location = model.Location;
                dbcat.Manufacturer = model.Manufacturer;
                dbcat.WikiLink = model.WikiLink;
                dbcat.ComponentTypeStatus = model.Status.ToString();
                if (model.selectedCat2 == "Emptyval")
                {
                    handler.saveComponentType(dbcat, Int32.Parse(model.selectedCat));
                }
                else if (model.selectedCat == "Emptyval" && model.selectedCat2 == "Emptyval")
                {

                }
                else
                {
                    handler.saveComponentType(dbcat, Int32.Parse(model.selectedCat),Int32.Parse(model.selectedCat2));
                }
              

                return RedirectToAction("Index", "HomePage");
            
        }

        public IActionResult ViewDeleteComponentType()
        {
            return View();
        }

        public IActionResult DeleteComponentType(ComponentType model)
        {
            BackEnd.Models.ComponentType component = new BackEnd.Models.ComponentType();
            component.ComponentTypeId = model.ComponentTypeId;
            ComponentTypeHandler handler = new ComponentTypeHandler(new bachelordbContext());
            handler.DeleteComponentType(component);
            return RedirectToAction("Index", "HomePage");
        }

        public IActionResult ViewUpdateComponentType()
        {
            return View();
        }

        public IActionResult UpdateComponentType(ComponentType model)
        {
            BackEnd.Models.ComponentType component = new BackEnd.Models.ComponentType();
            component.ComponentTypeId = model.ComponentTypeId;
            ComponentTypeHandler handler = new ComponentTypeHandler(new bachelordbContext());
            var newcat = handler.getComponentType(component);
            if (newcat.ComponentName != null)
            {
                newcat.AdminComment = model.AdminComment;
                newcat.ComponentInfo = model.ComponentInfo;
                newcat.ComponentName = model.ComponentName;
                //dbcat.ComponentTypeStatus
                newcat.Datasheet = model.Datasheet;
                newcat.ImageUrl = model.ImageUrl;
                newcat.Location = model.Location;
                newcat.Manufacturer = model.Manufacturer;
                newcat.WikiLink = model.WikiLink;
                newcat.ComponentTypeStatus = model.Status.ToString();

                handler.UpdateComponentType(newcat);

                return RedirectToAction("Index", "HomePage");
            }
            else
            {
                this.ModelState.AddModelError("AdminComment", "There is no component with that ID");
                return View("ViewUpdateComponentType");
            }
        }



    }
}