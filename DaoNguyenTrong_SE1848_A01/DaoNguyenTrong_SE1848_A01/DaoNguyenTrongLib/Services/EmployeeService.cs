using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAll();

        public Employee GetEmployeeById(int id) => _employeeRepository.GetById(id);

        public Employee GetEmployeeByUserName(string username) => _employeeRepository.GetByUserName(username);

        public void AddEmployee(Employee employee) => _employeeRepository.Add(employee);

        public void UpdateEmployee(Employee employee) => _employeeRepository.Update(employee);

        public void DeleteEmployee(int id) => _employeeRepository.Delete(id);
    }
}
