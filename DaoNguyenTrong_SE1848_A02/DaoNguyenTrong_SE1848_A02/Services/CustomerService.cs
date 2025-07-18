using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Customer> GetAll() => _repository.GetAll();

        public Customer? GetById(int id) => _repository.GetById(id);

        public void Add(Customer customer) => _repository.Add(customer);

        public void Update(Customer customer) => _repository.Update(customer);

        public void Delete(int id) => _repository.Delete(id);

        public IEnumerable<Customer> Search(string keyword) => _repository.Search(keyword);
    }
}
