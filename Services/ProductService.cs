using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository iReposiroty;

        public ProductService ()
        {
            iReposiroty = new ProductRepository();
        }

        public bool DeleteProduct(int id)
        {
            return iReposiroty.DeleteProduct(id);
        }

        public bool DeleteProduct(Product product)
        {
            return iReposiroty.DeleteProduct(product);
        }

        public void GenerateSampleDataset()
        {
            iReposiroty.GenerateSampleDataset();
        }

        public Product GetProduct(int id)
        {
            return iReposiroty.GetProduct(id);
        }

        public List<Product> GetProducts()
        {
            return iReposiroty.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iReposiroty.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return iReposiroty.UpdateProduct(product);
        }
    }
}
