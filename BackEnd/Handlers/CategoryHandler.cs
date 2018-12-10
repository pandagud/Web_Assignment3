using System;
using System.Collections.Generic;
using System.Text;
using BackEnd.Models;

namespace BackEnd.Handlers
{
    public class CategoryHandler
    {
        private bachelordbContext _context;

        public CategoryHandler(bachelordbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            if (category != null)
            {
                _context.category.Add(category);
                _context.SaveChanges();
            }
               
        }

    }
}
