using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<Employee> GetAll() => _context.Employees;

        public Employee GetById(int id) => _context.Employees.FirstOrDefault(e => e.EmployeeID == id);

        public Employee GetByUserName(string username) => _context.Employees.FirstOrDefault(e => e.UserName == username);

        public void Add(Employee employee)
        {
            employee.EmployeeID = (_context.Employees.Count > 0)
                ? _context.Employees.Max(e => e.EmployeeID) + 1
                : 1;
            _context.Employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.EmployeeID);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.UserName = employee.UserName;
                existing.Password = employee.Password;
                existing.JobTitle = employee.JobTitle;
            }
        }

        public void Delete(int id)
        {
            var emp = GetById(id);
            if (emp != null)
                _context.Employees.Remove(emp);
        }
    }
}
