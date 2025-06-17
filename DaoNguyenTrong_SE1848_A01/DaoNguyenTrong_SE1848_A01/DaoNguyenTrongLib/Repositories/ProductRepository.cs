using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<Product> GetAll() => _context.Products;

        public Product GetById(int id) => _context.Products.FirstOrDefault(p => p.ProductID == id);

        public void Add(Product product)
        {
            product.ProductID = (_context.Products.Count > 0)
                ? _context.Products.Max(p => p.ProductID) + 1
                : 1;
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.ProductID);
            if (existing != null)
            {
                existing.ProductName = product.ProductName;
                existing.CategoryID = product.CategoryID;
                existing.UnitPrice = product.UnitPrice;
                existing.UnitsInStock = product.UnitsInStock;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _context.Products.Remove(product);
        }

        public IEnumerable<Product> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _context.Products;

            keyword = keyword.ToLower();

            return _context.Products.Where(p =>
                (!string.IsNullOrEmpty(p.ProductName) && p.ProductName.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(p.CategoryID.ToString()) && p.CategoryID.ToString().ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(p.UnitPrice.ToString()) && p.UnitPrice.ToString().ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(p.UnitsInStock.ToString()) && p.UnitsInStock.ToString().ToLower().Contains(keyword))
            );
        }
    }
}
