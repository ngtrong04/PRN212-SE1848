using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DataAccessLayer;     // Đảm bảo đã add reference tới DataAccessLayer.dll
using BusinessObjects.Models;

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
            ErrorText.Text = "";

            if (RoleCombo.SelectedIndex == 0) // Nhân viên/Admin
            {
                string username = UsernameBox.Text.Trim();
                string password = PasswordBox.Password.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    ErrorText.Text = "Vui lòng nhập tên đăng nhập và mật khẩu!";
                    return;
                }

                using (var context = new LucySalesDataContext())
                {
                    var employee = context.Employees
                        .FirstOrDefault(emp => emp.UserName == username && emp.Password == password);

                    if (employee != null)
                    {
                        // Đăng nhập thành công, mở MainWindow (truyền employee nếu cần)
                        MainWindow mainWindow = new MainWindow(employee);
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        ErrorText.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                    }
                }
            }
            else // Khách hàng
            {
                string phone = PhoneBox.Text.Trim();

                if (string.IsNullOrEmpty(phone))
                {
                    ErrorText.Text = "Vui lòng nhập số điện thoại!";
                    return;
                }

                using (var context = new LucySalesDataContext())
                {
                    var customer = context.Customers
                        .FirstOrDefault(cus => cus.Phone == phone);

                    if (customer != null)
                    {
                        // Đăng nhập thành công, mở CustomerWindow (truyền customer nếu cần)
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
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RoleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeePanel == null || CustomerPanel == null)
                return;

            ErrorText.Text = ""; // Xóa lỗi cũ khi đổi vai trò

            if (RoleCombo.SelectedIndex == 0) // Nhân viên/Admin
            {
                EmployeePanel.Visibility = Visibility.Visible;
                CustomerPanel.Visibility = Visibility.Collapsed;
            }
            else // Khách hàng
            {
                EmployeePanel.Visibility = Visibility.Collapsed;
                CustomerPanel.Visibility = Visibility.Visible;
            }
        }
    }
}