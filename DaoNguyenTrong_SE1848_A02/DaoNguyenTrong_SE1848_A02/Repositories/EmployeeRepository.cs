using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LucySalesDataContext _context;

        public EmployeeRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        public EmployeeRepository()
        {
            _context = new LucySalesDataContext();

        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee? GetById(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            var existing = _context.Employees.Find(employee.EmployeeId);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.UserName = employee.UserName;
                existing.Password = employee.Password;
                existing.JobTitle = employee.JobTitle;
                existing.BirthDate = employee.BirthDate;
                existing.HireDate = employee.HireDate;
                existing.Address = employee.Address;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return _context.Employees.ToList();

            keyword = keyword.ToLower();

            return _context.Employees
                .Where(e =>
                    (!string.IsNullOrEmpty(e.Name) && e.Name.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(e.UserName) && e.UserName.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(e.JobTitle) && e.JobTitle.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(e.Address) && e.Address.ToLower().Contains(keyword))
                )
                .ToList();
        }
    }
}
