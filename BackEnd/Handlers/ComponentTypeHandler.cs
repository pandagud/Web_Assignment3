using System;
using System.Collections.Generic;
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

        public void saveComponentType(ComponentType model)
        {
            if (model != null)
            {
         
            }
        }
    }
}
