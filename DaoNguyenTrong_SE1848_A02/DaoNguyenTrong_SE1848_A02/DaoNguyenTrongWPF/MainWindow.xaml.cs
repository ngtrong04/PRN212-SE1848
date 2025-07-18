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
using DaoNguyenTrongWPF.ViewModels;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

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
            // Khởi động với màn hình quản lý khách hàng hoặc dashboard tùy ý
            MainContent.Content = new CustomerView();
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

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CategoryView();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            // Mở dialog chọn khoảng thời gian
            var dateRangeDialog = new DateRangeDialog();
            if (dateRangeDialog.ShowDialog() == true)
            {
                DateTime fromDate = dateRangeDialog.FromDate;
                DateTime toDate = dateRangeDialog.ToDate;

                using (var db = new LucySalesDataContext())
                {
                    // Lấy Order kèm Customer, Employee, OrderDetails
                    var orders = db.Orders
                        .Include(o => o.Customer)
                        .Include(o => o.Employee)
                        .Include(o => o.OrderDetails)
                        .Where(o => o.OrderDate >= fromDate && o.OrderDate <= toDate)
                        .OrderByDescending(o => o.OrderDate)
                        .ToList();

                    // Mapping sang ViewModel
                    var reportList = orders.Select(o => new OrderReportViewModel
                    {
                        OrderID = o.OrderId,
                        CustomerName = o.Customer?.ContactName ?? "",
                        EmployeeName = o.Employee?.Name ?? "",
                        OrderDate = o.OrderDate,
                        TotalAmount = o.TotalAmount 
                    }).ToList();

                    var reportWindow = new ReportResultWindow(reportList, fromDate, toDate);
                    reportWindow.ShowDialog();
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn đăng xuất không?", "Đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // Đóng MainWindow và mở lại LoginWindow
                var login = new LoginWindow();
                Application.Current.MainWindow = login;
                login.Show();
                this.Close();
            }
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new EmployeeView();
        }
    }
}
