using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO dao = new ProductDAO();
        public void DeleteProduct(Product p) => dao.DeleteProduct(p);
        public List<Product> GetProducts() => dao.GetProducts();
        public void SaveProduct(Product p) => dao.SaveProduct(p);
        public void UpdateProduct(Product p) => dao.UpdateProduct(p);
        public Product GetProductById(int id) => dao.GetProductById(id);


    }
}
