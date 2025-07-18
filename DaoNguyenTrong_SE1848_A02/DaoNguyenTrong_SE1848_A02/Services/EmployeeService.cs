using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Employee> GetAll() => _repository.GetAll();
        public Employee? GetById(int id) => _repository.GetById(id);
        public void Add(Employee employee) => _repository.Add(employee);
        public void Update(Employee employee) => _repository.Update(employee);
        public void Delete(int id) => _repository.Delete(id);
        public IEnumerable<Employee> Search(string keyword) => _repository.Search(keyword);
    }
}
