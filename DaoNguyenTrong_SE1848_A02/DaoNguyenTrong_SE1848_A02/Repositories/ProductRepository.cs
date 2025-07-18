using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LucySalesDataContext _context;

        public ProductRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        public ProductRepository()
        {
            _context = new LucySalesDataContext();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.Include(p => p.Category)
                                    .FirstOrDefault(p => p.ProductId == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            var existing = _context.Products.Find(product.ProductId);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.SupplierId = product.SupplierId;
                existing.CategoryId = product.CategoryId;
                existing.QuantityPerUnit = product.QuantityPerUnit;
                existing.UnitPrice = product.UnitPrice;
                existing.UnitsInStock = product.UnitsInStock;
                existing.UnitsOnOrder = product.UnitsOnOrder;
                existing.ReorderLevel = product.ReorderLevel;
                existing.Discontinued = product.Discontinued;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            keyword = keyword.ToLower();

            return _context.Products.Include(p => p.Category)
                .Where(p =>
                    (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(keyword))
                 || (p.Category != null && !string.IsNullOrEmpty(p.Category.CategoryName)
                     && p.Category.CategoryName.ToLower().Contains(keyword))
                )
                .ToList();
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
