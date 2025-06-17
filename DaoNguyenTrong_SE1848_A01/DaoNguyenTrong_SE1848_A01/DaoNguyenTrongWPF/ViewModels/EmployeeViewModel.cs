using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private readonly EmployeeService _employeeService;

        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get; set; }

        public EmployeeViewModel()
        {
            _employeeService = new EmployeeService(new DaoNguyenTrongLib.Repositories.EmployeeRepository());
            Employees = new ObservableCollection<Employee>(_employeeService.GetAllEmployees());
        }

        public void AddEmployee(Employee employee)
        {
            _employeeService.AddEmployee(employee);
            Employees.Add(employee);
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            _employeeService.UpdateEmployee(updatedEmployee);
            var oldEmp = Employees.FirstOrDefault(e => e.EmployeeID == updatedEmployee.EmployeeID);
            if (oldEmp != null)
            {
                int index = Employees.IndexOf(oldEmp);
                Employees[index] = updatedEmployee;
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeService.DeleteEmployee(employeeId);
            var emp = Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            if (emp != null)
                Employees.Remove(emp);
        }

        public void SearchEmployees(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Employees.Clear();
                foreach (var emp in _employeeService.GetAllEmployees())
                    Employees.Add(emp);
            }
            else
            {
                var filtered = _employeeService.GetAllEmployees()
                    .Where(e => (e.Name != null && e.Name.Contains(keyword))
                             || (e.UserName != null && e.UserName.Contains(keyword))
                             || (e.JobTitle != null && e.JobTitle.Contains(keyword)));
                Employees.Clear();
                foreach (var emp in filtered)
                    Employees.Add(emp);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
