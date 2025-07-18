using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LucySalesDataContext _context;

        public CustomerRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        public CustomerRepository()
        {
            // Nếu không có dòng này, _context sẽ luôn null!
            _context = new LucySalesDataContext();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var existing = _context.Customers.Find(customer.CustomerId);
            if (existing != null)
            {
                existing.CompanyName = customer.CompanyName;
                existing.ContactName = customer.ContactName;
                existing.ContactTitle = customer.ContactTitle;
                existing.Address = customer.Address;
                existing.Phone = customer.Phone;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Customer> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _context.Customers.ToList();

            keyword = keyword.ToLower();

            return _context.Customers
                .Where(c =>
                    (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(c.ContactName) && c.ContactName.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(c.ContactTitle) && c.ContactTitle.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(c.Address) && c.Address.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(c.Phone) && c.Phone.ToLower().Contains(keyword))
                )
                .ToList();
        }
    }
}
