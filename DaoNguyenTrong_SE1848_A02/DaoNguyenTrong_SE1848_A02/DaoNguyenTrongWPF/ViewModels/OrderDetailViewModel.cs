using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;
using Services;

namespace DaoNguyenTrongWPF.ViewModels
{
    public class OrderDetailViewModel
    {
        public ObservableCollection<OrderDetailDisplay> OrderDetails { get; set; }

        public OrderDetailViewModel(int orderId)
        {
            // Sử dụng đúng repository đã có
            var orderRepo = new OrderRepository();
            var employeeRepo = new EmployeeRepository();
            var orderDetailRepo = new OrderDetailRepository();

            var order = orderRepo.GetAll().FirstOrDefault(o => o.OrderId == orderId);
            var employeeName = order != null
                ? employeeRepo.GetAll().FirstOrDefault(e => e.EmployeeId == order.EmployeeId)?.Name ?? ""
                : "";

            var details = orderDetailRepo.GetByOrderId(orderId)
                .Select(od => new OrderDetailDisplay
                {
                    OrderId = od.OrderId,
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount,                   
                    EmployeeName = employeeName
                })
                .ToList();

            OrderDetails = new ObservableCollection<OrderDetailDisplay>(details);
        }
    }
}
