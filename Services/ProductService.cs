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
        public void GenerateSampleDataset()
        {
            iReposiroty.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return iReposiroty.GetProducts();
        }

        public bool SaveProduct(Product product)
        {
            return iReposiroty.SaveProduct(product);
        }
    }
}
