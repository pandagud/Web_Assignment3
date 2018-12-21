using System;
using System.Collections.Generic;
using System.Linq;
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

        public Category getComponent(Category model)
        {
            if (model != null)
            {
                Category category =
                    _context.category.FirstOrDefault(cat => cat.CategoryId == model.CategoryId);
                return category;
            }
            return new Category();

        }

        public void DeleteCateogry(Category model)
        {
            if (model != null)
            {
                Category category =
                    _context.category.FirstOrDefault(cat => cat.CategoryId == model.CategoryId);
                _context.category.Remove(category);
                _context.SaveChanges();
            }
        }

        public void UpdateCategory(Category model)
        {
            Category oldcategory =
                _context.category.FirstOrDefault(cat => cat.CategoryId == model.CategoryId);
            if (oldcategory != null)
            {
                oldcategory.Name = model.Name;
                _context.category.Update(oldcategory);
                _context.SaveChanges();
            }
        }


    }
}
