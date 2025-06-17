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
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for OrderHistoryView.xaml
    /// </summary>
    public partial class OrderHistoryView : UserControl
    {
        public OrderHistoryView(Customer customer)
        {
            InitializeComponent();
            LoadOrderHistory(customer.CustomerID);
        }

        private void LoadOrderHistory(int customerId)
        {
            var repo = new OrderRepository(); // Bạn cần tạo OrderRepository tương tự CustomerRepository
            List<Order> orders = repo.GetOrdersByCustomerId(customerId).ToList();

            OrderGrid.ItemsSource = orders;
        }
    }
}
