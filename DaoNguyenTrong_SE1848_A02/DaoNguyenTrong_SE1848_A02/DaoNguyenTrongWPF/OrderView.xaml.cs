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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {

        private OrderViewModel ViewModel => DataContext as OrderViewModel;
        public OrderView()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OrderDialog(); // Cần tạo OrderDialog cho Add
            if (dialog.ShowDialog() == true)
            {
                var newOrder = dialog.Order;
                ViewModel.AddOrder(newOrder);
            }
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem is Order selectedOrder)
            {
                // Sửa lại: OrderDetailView là Window, truyền OrderID vào constructor
                var detailsWindow = new OrderDetailView(selectedOrder.OrderId);
                detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an order to view details.", "Order Details", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem is Order selectedOrder)
            {
                var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đơn hàng ID '{selectedOrder.OrderId}'?",
                                             "Xóa đơn hàng", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    ViewModel.DeleteOrder(selectedOrder.OrderId);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đơn hàng để xóa.", "Xóa đơn hàng", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchBox.Text.Trim();
            ViewModel.SearchOrders(keyword);
        }
    }
}
