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
using DaoNguyenTrongWPF.ViewModels;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for ReportResultWindow.xaml
    /// </summary>
    public partial class ReportResultWindow : Window
    {
        public ReportResultWindow(List<OrderReportViewModel> orders, DateTime from, DateTime to)
        {
            InitializeComponent();
            TimeRangeText.Text = $"From {from:dd/MM/yyyy} to {to:dd/MM/yyyy}";
            OrderGrid.ItemsSource = orders;

            TotalOrderText.Text = orders.Count.ToString();
            TotalRevenueText.Text = orders.Sum(o => o.TotalAmount).ToString("N0") + " đ";
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
