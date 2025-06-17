using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DaoNguyenTrongWPF
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (RoleCombo.SelectedIndex == 0) // Employee
            {
                string username = UsernameBox.Text.Trim();
                string password = PasswordBox.Password.Trim();

                var employee = DaoNguyenTrongLib.DataContext.Instance.Employees
                    .FirstOrDefault(emp => emp.UserName == username && emp.Password == password);

                if (employee != null)
                {
                    // Đăng nhập thành công, mở MainWindow
                    MainWindow mainWindow = new MainWindow(employee);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    ErrorText.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                }
            }
            else // Customer
            {
                string phone = PhoneBox.Text.Trim();
                var customer = DaoNguyenTrongLib.DataContext.Instance.Customers
                    .FirstOrDefault(cus => cus.Phone == phone);

                if (customer != null)
                {
                    // Đăng nhập thành công, mở CustomerView (window riêng cho khách hàng)
                    CustomerWindow customerWindow = new CustomerWindow(customer);
                    customerWindow.Show();
                    this.Close();
                }
                else
                {
                    ErrorText.Text = "Số điện thoại không tồn tại!";
                }
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RoleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeePanel == null || CustomerPanel == null)
                return;

            if (RoleCombo.SelectedIndex == 0) // Employee
            {
                EmployeePanel.Visibility = Visibility.Visible;
                CustomerPanel.Visibility = Visibility.Collapsed;
            }
            else // Customer
            {
                EmployeePanel.Visibility = Visibility.Collapsed;
                CustomerPanel.Visibility = Visibility.Visible;
            }
        }
    }
}