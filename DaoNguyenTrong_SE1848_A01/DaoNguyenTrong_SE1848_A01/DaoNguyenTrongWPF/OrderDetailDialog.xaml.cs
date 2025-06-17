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
        public OrderDetailDialog(int orderId)
        {
            InitializeComponent();
            OrderDetail = new OrderDetail { OrderID = orderId };
            DataContext = OrderDetail;
        }

        public OrderDetailDialog(OrderDetail existingDetail)
        {
            InitializeComponent();
            OrderDetail = existingDetail;
            DataContext = OrderDetail;
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
