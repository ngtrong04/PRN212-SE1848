using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts() => _productRepository.GetAll();

        public Product GetProductById(int id) => _productRepository.GetById(id);

        public void AddProduct(Product product) => _productRepository.Add(product);

        public void UpdateProduct(Product product) => _productRepository.Update(product);

        public void DeleteProduct(int id) => _productRepository.Delete(id);

        public IEnumerable<Product> SearchProducts(string keyword) => _productRepository.Search(keyword);
    }
}
