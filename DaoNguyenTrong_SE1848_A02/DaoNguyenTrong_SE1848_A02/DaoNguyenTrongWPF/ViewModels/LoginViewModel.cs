using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Services;
using System.Windows;
using BusinessObjects.Models;
using Repositories;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _phone;
        private bool _isLoginSuccessful;
        private Employee _loggedEmployee;
        private Customer _loggedCustomer;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(); }
        }

        public bool IsLoginSuccessful
        {
            get => _isLoginSuccessful;
            set { _isLoginSuccessful = value; OnPropertyChanged(); }
        }

        public Employee LoggedEmployee
        {
            get => _loggedEmployee;
            set { _loggedEmployee = value; OnPropertyChanged(); }
        }

        public Customer LoggedCustomer
        {
            get => _loggedCustomer;
            set { _loggedCustomer = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Đăng nhập nhân viên
        public bool LoginEmployee()
        {
            var employeeRepo = new EmployeeRepository();
            var emp = employeeRepo.GetAll()
                .FirstOrDefault(e => e.UserName == Username && e.Password == Password);

            if (emp != null)
            {
                LoggedEmployee = emp;
                IsLoginSuccessful = true;
                return true;
            }
            else
            {
                IsLoginSuccessful = false;
                return false;
            }
        }

        // Đăng nhập khách hàng (bằng số điện thoại)
        public bool LoginCustomer()
        {
            var customerRepo = new CustomerRepository();
            var cust = customerRepo.GetAll()
                .FirstOrDefault(c => c.Phone == Phone);

            if (cust != null)
            {
                LoggedCustomer = cust;
                IsLoginSuccessful = true;
                return true;
            }
            else
            {
                IsLoginSuccessful = false;
                return false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
