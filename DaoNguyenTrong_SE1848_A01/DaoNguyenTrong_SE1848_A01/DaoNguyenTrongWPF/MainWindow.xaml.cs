using System.Text;
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
using DaoNguyenTrongWPF.ViewModels;
using DaoNguyenTrongLib;

namespace DaoNguyenTrongWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(Employee employee)
        {
            InitializeComponent();
            // Lưu employee vào biến hoặc sử dụng tùy ý
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CustomerView();
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductView();
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new OrderView();
        }

        //private void Employees_Click(object sender, RoutedEventArgs e)
        //{
        //    MainContent.Content = new EmployeeView();
        //}

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CategoryView();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            // Giả sử bạn đã có hàm lấy danh sách đơn hàng và dialog chọn thời gian
            var dateRangeDialog = new DateRangeDialog();
            if (dateRangeDialog.ShowDialog() == true)
            {
                DateTime fromDate = dateRangeDialog.FromDate;
                DateTime toDate = dateRangeDialog.ToDate;

                // Lấy danh sách đơn hàng theo thời gian
                var orders = DaoNguyenTrongLib.DataContext.Instance.Orders
    .Where(o => o.OrderDate.Date >= fromDate.Date && o.OrderDate.Date <= toDate.Date)
    .OrderByDescending(o => o.OrderDate)
    .Select(o => new OrderReportViewModel
    {
        OrderID = o.OrderID,
        CustomerName = DaoNguyenTrongLib.DataContext.Instance.Customers.FirstOrDefault(c => c.CustomerID == o.CustomerID)?.ContactName ?? "",
        EmployeeName = DaoNguyenTrongLib.DataContext.Instance.Employees.FirstOrDefault(emp => emp.EmployeeID == o.EmployeeID)?.Name ?? "",
        OrderDate = o.OrderDate,
        TotalAmount = o.TotalAmount // hoặc tính lại nếu muốn
    })
    .ToList();

                // Mở cửa sổ báo cáo
                var reportWindow = new ReportResultWindow(orders, fromDate, toDate);
                reportWindow.ShowDialog();
            }



        }
    }
}