using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;
using Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly IEmployeeRepository _employeeRepository;

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get => _employees;
            set { _employees = value; OnPropertyChanged(); }
        }

        private Employee _selectedEmployee;
        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set { _selectedEmployee = value; OnPropertyChanged(); }
        }

        public EmployeeViewModel()
        {
            _employeeRepository = new EmployeeRepository();
            LoadEmployees();
        }

        public void LoadEmployees()
        {
            Employees = new ObservableCollection<Employee>(_employeeRepository.GetAll());
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.Add(employee);
            Employees.Add(employee);
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            _employeeRepository.Update(updatedEmployee);
            var oldEmp = Employees.FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeId);
            if (oldEmp != null)
            {
                int index = Employees.IndexOf(oldEmp);
                Employees[index] = updatedEmployee;
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.Delete(employeeId);
            var emp = Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (emp != null)
                Employees.Remove(emp);
        }

        public void SearchEmployees(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadEmployees();
            }
            else
            {
                var filtered = _employeeRepository.GetAll()
                    .Where(e => (e.Name != null && e.Name.Contains(keyword))
                             || (e.UserName != null && e.UserName.Contains(keyword))
                             || (e.JobTitle != null && e.JobTitle.Contains(keyword)));
                Employees = new ObservableCollection<Employee>(filtered);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
