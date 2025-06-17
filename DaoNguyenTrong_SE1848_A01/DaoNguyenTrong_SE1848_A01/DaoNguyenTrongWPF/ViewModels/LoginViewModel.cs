using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Services;
using System.Windows;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private bool _isLoginSuccessful;

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

        public bool IsLoginSuccessful
        {
            get => _isLoginSuccessful;
            set { _isLoginSuccessful = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Login()
        {
            // Giả lập - bạn có thể kiểm tra qua EmployeeService hoặc UserService nếu có
            var employeeService = new EmployeeService(new DaoNguyenTrongLib.Repositories.EmployeeRepository());
            var employee = employeeService.GetEmployeeByUserName(Username);

            if (employee != null && employee.Password == Password)
            {
                IsLoginSuccessful = true;
                return true;
            }
            else
            {
                IsLoginSuccessful = false;
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
