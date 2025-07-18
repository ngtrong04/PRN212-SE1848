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
    /// Interaction logic for CustomerView.xaml
    /// </summary>
    public partial class CustomerView : UserControl
    {
        private CustomerViewModel ViewModel => (CustomerViewModel)this.DataContext;
        public CustomerView()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
            //CustomerGrid.ItemsSource = DaoNguyenTrongLib.DataContext.Instance.Customers;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog(); // You need to create a CustomerDialog window for adding/editing
            if (dialog.ShowDialog() == true)
            {
                var newCustomer = dialog.Customer;
                ViewModel.AddCustomer(newCustomer);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customer selectedCustomer)
            {
                var dialog = new CustomerDialog(selectedCustomer); // Pass the selected customer
                if (dialog.ShowDialog() == true)
                {
                    var updatedCustomer = dialog.Customer;
                    ViewModel.UpdateCustomer(updatedCustomer);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Edit Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show($"Are you sure you want to delete customer '{selectedCustomer.CompanyName}'?",
                                             "Delete Customer", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ViewModel.DeleteCustomer(selectedCustomer.CustomerId);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Delete Customer", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            ViewModel.SearchCustomers(keyword);
        }
    }
}
