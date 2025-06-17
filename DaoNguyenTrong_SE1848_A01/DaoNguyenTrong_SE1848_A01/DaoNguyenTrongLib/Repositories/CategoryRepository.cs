using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<Category> GetAll() => _context.Categories;

        public Category GetById(int id) => _context.Categories.FirstOrDefault(c => c.CategoryID == id);

        public void Add(Category category)
        {
            category.CategoryID = (_context.Categories.Count > 0)
                ? _context.Categories.Max(c => c.CategoryID) + 1
                : 1;
            _context.Categories.Add(category);
        }

        public void Update(Category category)
        {
            var existing = GetById(category.CategoryID);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
            }
        }

        public void Delete(int id)
        {
            var cat = GetById(id);
            if (cat != null)
                _context.Categories.Remove(cat);
        }

        public IEnumerable<Category> Search(string keyword)
        {
            return _context.Categories
                .Where(c => (c.CategoryName != null && c.CategoryName.Contains(keyword))
                         || (c.Description != null && c.Description.Contains(keyword)));
        }
    }
}
