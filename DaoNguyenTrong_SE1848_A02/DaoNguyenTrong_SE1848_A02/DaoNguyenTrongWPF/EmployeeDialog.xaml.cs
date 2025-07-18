using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessObjects.Models;


namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for EmployeeDialog.xaml
    /// </summary>
    public partial class EmployeeDialog : Window
    {
        public Employee Employee { get; set; }

        public EmployeeDialog()
        {
            InitializeComponent();
            Employee = new Employee();
            DataContext = Employee;
        }

        public EmployeeDialog(Employee employee)
        {
            InitializeComponent();
            // Tạo bản sao để tránh sửa trực tiếp đối tượng gốc nếu muốn
            Employee = new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                UserName = employee.UserName,
                Password = employee.Password,
                JobTitle = employee.JobTitle,
                BirthDate = employee.BirthDate,
                HireDate = employee.HireDate,
                Address = employee.Address
            };
            DataContext = Employee;
            // Nếu muốn gán mật khẩu vào PasswordBox khi sửa, có thể thêm:
            if (!string.IsNullOrEmpty(employee.Password))
                PasswordBox.Password = employee.Password;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            // Lấy mật khẩu từ PasswordBox (không binding được trực tiếp)
            Employee.Password = PasswordBox.Password;
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
