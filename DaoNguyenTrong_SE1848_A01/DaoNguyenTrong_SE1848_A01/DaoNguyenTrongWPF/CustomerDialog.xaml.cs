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
    /// Interaction logic for CustomerDialog.xaml
    /// </summary>
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; set; }
        public CustomerDialog()
        {
            InitializeComponent();
            Customer = new Customer();
            DataContext = Customer;
        }
        public CustomerDialog(Customer existingCustomer)
        {
            InitializeComponent();
            Customer = existingCustomer;
            DataContext = Customer;
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
