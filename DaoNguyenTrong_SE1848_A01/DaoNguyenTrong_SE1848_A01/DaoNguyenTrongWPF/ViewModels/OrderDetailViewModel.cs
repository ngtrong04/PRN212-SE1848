using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class OrderDetailViewModel
    {
        public ObservableCollection<OrderDetailDisplay> OrderDetails { get; set; } // Fix: Change the type to match the collection being assigned.

        public OrderDetailViewModel(int orderId)
        {
            // Giả sử bạn có các list: DataContext.Orders, DataContext.Employees, DataContext.OrderDetails
            var context = DaoNguyenTrongLib.DataContext.Instance;

            var order = context.Orders.FirstOrDefault(o => o.OrderID == orderId);
            var employeeName = order != null
                ? context.Employees.FirstOrDefault(e => e.EmployeeID == order.EmployeeID)?.Name
                : "";

            var details = context.OrderDetails
                .Where(od => od.OrderID == orderId)
                .Select(od => new OrderDetailDisplay
                {
                    OrderID = od.OrderID,
                    ProductID = od.ProductID,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount,
                    EmployeeName = employeeName // gán cho từng dòng
                })
                .ToList();
            OrderDetails = new ObservableCollection<OrderDetailDisplay>(details);
        }
    }
}
