using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers() => _customerRepository.GetAll();

        public Customer GetCustomerById(int id) => _customerRepository.GetById(id);

        public void AddCustomer(Customer customer) => _customerRepository.Add(customer);

        public void UpdateCustomer(Customer customer) => _customerRepository.Update(customer);

        public void DeleteCustomer(int id) => _customerRepository.Delete(id);

        public IEnumerable<Customer> SearchCustomers(string keyword) => _customerRepository.Search(keyword);
    }
}
