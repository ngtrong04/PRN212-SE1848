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
using BusinessObjects.Models;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for OrderDetailDialog.xaml
    /// </summary>
    public partial class OrderDetailDialog : Window
    {
        public OrderDetail OrderDetail { get; set; }

        public OrderDetailDialog()
        {
            InitializeComponent();
            OrderDetail = new OrderDetail();
            DataContext = OrderDetail;
        }

        public OrderDetailDialog(OrderDetail orderDetail)
        {
            InitializeComponent();
            // Tạo bản sao để sửa mà không ảnh hưởng đến dữ liệu gốc nếu muốn
            OrderDetail = new OrderDetail
            {
                OrderId = orderDetail.OrderId,
                ProductId = orderDetail.ProductId,
                UnitPrice = orderDetail.UnitPrice,
                Quantity = orderDetail.Quantity,
                Discount = orderDetail.Discount
            };
            DataContext = OrderDetail;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            // Nếu cần kiểm tra dữ liệu hợp lệ thì bổ sung tại đây
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
