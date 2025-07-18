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

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Customer CurrentCustomer { get; set; }
        public CustomerWindow(Customer customer)
        {
            InitializeComponent();
            CurrentCustomer = customer;
            // Mặc định hiển thị thông tin cá nhân
            MainContent.Content = new CustomerProfileView(CurrentCustomer);
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            // Hiển thị lại view sửa hồ sơ, hoặc mở dialog sửa hồ sơ
            MainContent.Content = new CustomerProfileView(CurrentCustomer);
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OrderHistory_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new OrderHistoryView(CurrentCustomer);
        }
    }
}
