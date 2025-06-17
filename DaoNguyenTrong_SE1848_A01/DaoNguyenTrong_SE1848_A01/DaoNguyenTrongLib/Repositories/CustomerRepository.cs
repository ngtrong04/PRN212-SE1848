using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<Customer> GetAll() => _context.Customers;

        public Customer GetById(int id) => _context.Customers.FirstOrDefault(c => c.CustomerID == id);

        public void Add(Customer customer)
        {
            customer.CustomerID = (_context.Customers.Count > 0)
                ? _context.Customers.Max(c => c.CustomerID) + 1
                : 1;
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existing = GetById(customer.CustomerID);
            if (existing != null)
            {
                existing.CompanyName = customer.CompanyName;
                existing.ContactName = customer.ContactName;
                existing.ContactTitle = customer.ContactTitle;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
                _context.Customers.Remove(customer);
        }

        public IEnumerable<Customer> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _context.Customers;

            keyword = keyword.ToLower();

            return _context.Customers.Where(c =>
                (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(keyword))
                || (!string.IsNullOrEmpty(c.ContactName) && c.ContactName.ToLower().Contains(keyword))
                || (!string.IsNullOrEmpty(c.ContactTitle) && c.ContactTitle.ToLower().Contains(keyword))
                || (!string.IsNullOrEmpty(c.Address) && c.Address.ToLower().Contains(keyword))
                || (!string.IsNullOrEmpty(c.Phone) && c.Phone.ToLower().Contains(keyword))
            );
        }
    }
}
