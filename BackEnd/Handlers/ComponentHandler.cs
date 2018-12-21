using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BackEnd.Models;

namespace BackEnd.Handlers
{
   public  class ComponentHandler
    {
        private bachelordbContext _context;

        public ComponentHandler(bachelordbContext context)
        {
            _context = context;
        }

        public void saveComponent(Component model)
        {
            if (model != null)
            {
                _context.component.Add(model);
                _context.SaveChanges();
            }
               
              
        }

        public Component getComponent(Component model)
        {
            if (model != null)
            {
                Component component =
                    _context.component.FirstOrDefault(comp => comp.ComponentId == model.ComponentId);
                return component;
            }
            return new Component();
            
        }

        public void DeleteComponent(Component model)
        {
            if (model != null)
            {
                Component component = _context.component.FirstOrDefault(comp => comp.ComponentId == model.ComponentId);
                _context.component.Remove(component);
                _context.SaveChanges();
            }
        }

        public void EditComponent(Component model)
        {
            Component oldComponent = _context.component.FirstOrDefault(comp => comp.ComponentId == model.ComponentId);

            if (oldComponent != null)
            {
                oldComponent.AdminComment = model.AdminComment;
                oldComponent.ComponentNumber = model.ComponentNumber;
                oldComponent.Status = model.Status;
                oldComponent.UserComment = model.UserComment;

                _context.component.Update(oldComponent);
                _context.SaveChanges();

            }
        }



    }
}
