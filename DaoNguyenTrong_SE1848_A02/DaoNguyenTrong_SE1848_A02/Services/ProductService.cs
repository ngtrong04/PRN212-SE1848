using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Product> GetAll() => _repository.GetAll();

        public Product? GetById(int id) => _repository.GetById(id);

        public void Add(Product product) => _repository.Add(product);

        public void Update(Product product) => _repository.Update(product);

        public void Delete(int id) => _repository.Delete(id);

        public IEnumerable<Product> Search(string keyword) => _repository.Search(keyword);

        public IEnumerable<Product> GetByCategoryId(int categoryId) => _repository.GetByCategoryId(categoryId);
    }
}
