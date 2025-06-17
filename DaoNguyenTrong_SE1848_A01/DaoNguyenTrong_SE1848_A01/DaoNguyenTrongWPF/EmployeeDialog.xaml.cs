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
using DaoNguyenTrongLib.Models;

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

        public EmployeeDialog(Employee existingEmployee)
        {
            InitializeComponent();
            Employee = existingEmployee;
            DataContext = Employee;
        }
        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
