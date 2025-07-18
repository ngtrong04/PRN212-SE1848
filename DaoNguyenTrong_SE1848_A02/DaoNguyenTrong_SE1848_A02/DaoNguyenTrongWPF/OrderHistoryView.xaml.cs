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
    /// Interaction logic for OrderHistoryView.xaml
    /// </summary>
    public partial class OrderHistoryView : UserControl
    {
        public OrderHistoryView(Customer customer)
        {
            InitializeComponent();
            LoadOrderHistory(customer.CustomerId);
        }

        private void LoadOrderHistory(int customerId)
        {
            // Khởi tạo OrderRepository (dùng constructor không tham số)
            var repo = new OrderRepository();

            // Lấy danh sách đơn hàng của khách hàng từ repo
            var orders = repo.GetOrdersByCustomerId(customerId);

            // Gán dữ liệu cho DataGrid
            OrderGrid.ItemsSource = orders;
        }
    }
}
