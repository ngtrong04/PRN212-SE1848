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
using BusinessObjects.Models;
using DaoNguyenTrongWPF.ViewModels;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl
    {
        private EmployeeViewModel VM => DataContext as EmployeeViewModel;

        public EmployeeView()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new EmployeeDialog();
            if (dlg.ShowDialog() == true)
            {
                VM.AddEmployee(dlg.Employee);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selected)
            {
                // Truyền bản sao hoặc đối tượng gốc vào dialog (tùy nhu cầu)
                var dlg = new EmployeeDialog(selected);
                if (dlg.ShowDialog() == true)
                {
                    VM.UpdateEmployee(dlg.Employee);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeGrid.SelectedItem is Employee selected)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    VM.DeleteEmployee(selected.EmployeeId);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên để xóa!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
