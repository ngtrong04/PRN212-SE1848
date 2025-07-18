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
using Repositories;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for CustomerProfileView.xaml
    /// </summary>
    public partial class CustomerProfileView : UserControl
    {
        private Customer _customer;
        private CustomerRepository _repo = new CustomerRepository();
        public CustomerProfileView(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            CompanyNameBox.Text = customer.CompanyName;
            ContactNameBox.Text = customer.ContactName;
            ContactTitleBox.Text = customer.ContactTitle;
            AddressBox.Text = customer.Address;
            PhoneBox.Text = customer.Phone;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _customer.CompanyName = CompanyNameBox.Text.Trim();
            _customer.ContactName = ContactNameBox.Text.Trim();
            _customer.ContactTitle = ContactTitleBox.Text.Trim();
            _customer.Address = AddressBox.Text.Trim();
            _customer.Phone = PhoneBox.Text.Trim();

            _repo.Update(_customer);

            MessageBox.Show("Đã lưu thông tin!", "Thông báo");
        }
    }
}
