using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LucySalesDataContext _context;

        public CategoryRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        public CategoryRepository()
        {
            _context = new LucySalesDataContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {
            var existing = _context.Categories.Find(category.CategoryId);
            if (existing != null)
            {
                existing.CategoryName = category.CategoryName;
                existing.Description = category.Description;
                existing.Picture = category.Picture;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            if (entity != null)
            {
                _context.Categories.Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Category> Search(string keyword)
        {
            return _context.Categories
                .Where(c => (c.CategoryName != null && c.CategoryName.Contains(keyword))
                         || (c.Description != null && c.Description.Contains(keyword)))
                .ToList();
        }
    }
}
