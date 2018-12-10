using System;
using System.Collections.Generic;
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

    }
}
