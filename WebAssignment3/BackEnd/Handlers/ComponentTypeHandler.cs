using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Models;

namespace BackEnd.Handlers
{
    public class ComponentTypeHandler
    {
        private bachelordbContext _context;
        public ComponentTypeHandler(bachelordbContext context)
        {
            _context = context;
        }

        public void saveComponentType(ComponentType model,int categoryId)
        {
            if (model != null)
            {

                _context.componentType.Add(model);
                _context.SaveChanges();


                ComponentType component =
                    _context.componentType.FirstOrDefault(compt => compt.ComponentName == model.ComponentName && compt.ImageUrl==model.ImageUrl);


                var catcomponent = new Category_ComponentType();
                catcomponent.ComponentTypeId = (int) component.ComponentTypeId;
                catcomponent.CategoryId = categoryId;

                _context.categoryComponentTypes.Add(catcomponent);
                _context.SaveChanges();



               
            }
        }

        public void saveComponentType(ComponentType model, int categoryId,int categoryid2)
        {
            if (model != null)
            {

                _context.componentType.Add(model);
                _context.SaveChanges();


                ComponentType component =
                    _context.componentType.FirstOrDefault(compt => compt.ComponentName == model.ComponentName && compt.ImageUrl == model.ImageUrl);


                var catcomponent = new Category_ComponentType();
                catcomponent.ComponentTypeId = (int)component.ComponentTypeId;
                catcomponent.CategoryId = categoryId;

                _context.categoryComponentTypes.Add(catcomponent);
                _context.SaveChanges();


                var catcomponent2 = new Category_ComponentType();
                catcomponent2.ComponentTypeId = (int)component.ComponentTypeId;
                catcomponent2.CategoryId = categoryid2;

                _context.categoryComponentTypes.Add(catcomponent2);
                _context.SaveChanges();








            }
        }

        public void DeleteComponentType(ComponentType model)
        {
            if (model != null)
            {
                ComponentType component = _context.componentType.FirstOrDefault(compt => compt.ComponentTypeId == model.ComponentTypeId);

                foreach (var componentitem in _context.component.ToList())
                {
                    if (componentitem.ComponentTypeId == component.ComponentTypeId)
                    {
                        _context.Remove(componentitem);
                    }

                    _context.SaveChanges();
                }

                foreach (var componentTypeitem in _context.categoryComponentTypes.ToList())
                {
                    if (componentTypeitem.ComponentTypeId == component.ComponentTypeId)
                    {
                        _context.Remove(componentTypeitem);
                    }

                    _context.SaveChanges();
                }
                _context.componentType.Remove(component);
                _context.SaveChanges();
            }
        }

        public ComponentType getComponentType(ComponentType model)
        {
            if (model != null)
            {
                ComponentType component =
                    _context.componentType.FirstOrDefault(compt => compt.ComponentTypeId == model.ComponentTypeId);
                return component;
            }
            return new ComponentType();
        }

        public void UpdateComponentType(ComponentType model)
        {
            ComponentType oldcomponent =
                _context.componentType.FirstOrDefault(compt => compt.ComponentTypeId == model.ComponentTypeId);

            if (oldcomponent != null)
            {
                oldcomponent.AdminComment = model.AdminComment;
                oldcomponent.ComponentInfo = model.ComponentInfo;
                oldcomponent.ComponentName = model.ComponentName;
                oldcomponent.ComponentTypeStatus = model.ComponentTypeStatus;
                oldcomponent.Datasheet = model.Datasheet;
                oldcomponent.ImageUrl = model.ImageUrl;
                oldcomponent.Manufacturer = model.Manufacturer;
                oldcomponent.Location = model.Location;


                _context.componentType.Update(oldcomponent);
                _context.SaveChanges();

            }
        }


        public List<ComponentType> GetAlleComponentTypes()
        {
            List<ComponentType> listcategories = new List<ComponentType>();

            if (_context.componentType != null)
            {
                listcategories = _context.componentType.ToList();
            }

            return listcategories;
        }

    }
}
