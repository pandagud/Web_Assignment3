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

                foreach (var categoryComponentType in _context.categoryComponentTypes.ToList())
                {
                    if (category.CategoryId == categoryComponentType.CategoryId)
                    {
                        _context.Remove(categoryComponentType);
                    }
                }
                _context.SaveChanges();


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

        public List<Category> getAllCategory()
        {
            List<Category> listcategories = new List<Category>();

            if (_context.category != null)
            {
                listcategories = _context.category.ToList();
            }

            return listcategories;
        }

        public List<Category_ComponentType> GetallCategoryComponentTypes()
        {
            return _context.categoryComponentTypes.ToList();
        }


    }
}
