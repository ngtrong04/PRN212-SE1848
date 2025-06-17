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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongWPF.ViewModels;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        private EmployeeViewModel ViewModel => DataContext as EmployeeViewModel;
        public EmployeeView()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new EmployeeDialog(); // Cần tạo EmployeeDialog cho Add
            if (dialog.ShowDialog() == true)
            {
                var newEmployee = dialog.Employee;
                ViewModel.AddEmployee(newEmployee);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selectedEmployee)
            {
                var dialog = new EmployeeDialog(selectedEmployee); // Truyền employee đã chọn để sửa
                if (dialog.ShowDialog() == true)
                {
                    var updatedEmployee = dialog.Employee;
                    ViewModel.UpdateEmployee(updatedEmployee);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa.", "Sửa nhân viên", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selectedEmployee)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên '{selectedEmployee.Name}'?",
                                             "Xóa nhân viên", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ViewModel.DeleteEmployee(selectedEmployee.EmployeeID);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa.", "Xóa nhân viên", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
