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
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly OrderService _orderService;

        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder { get; set; }

        public OrderViewModel()
        {
            _orderService = new OrderService(new DaoNguyenTrongLib.Repositories.OrderRepository());
            Orders = new ObservableCollection<Order>(_orderService.GetAllOrders());
        }

        public void AddOrder(Order order)
        {
            _orderService.AddOrder(order);
            Orders.Add(order);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            _orderService.UpdateOrder(updatedOrder);
            var oldOrder = Orders.FirstOrDefault(o => o.OrderID == updatedOrder.OrderID);
            if (oldOrder != null)
            {
                int index = Orders.IndexOf(oldOrder);
                Orders[index] = updatedOrder;
            }
        }

        public void DeleteOrder(int orderId)
        {
            _orderService.DeleteOrder(orderId);
            var order = Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order != null)
                Orders.Remove(order);
        }

        public void SearchOrders(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Orders.Clear();
                foreach (var order in _orderService.GetAllOrders())
                    Orders.Add(order);
            }
            else
            {
                var filtered = _orderService.GetAllOrders()
                    .Where(o => o.CustomerID.ToString().Contains(keyword)
                             || o.EmployeeID.ToString().Contains(keyword)
                             || o.OrderDate.ToString().Contains(keyword));
                Orders.Clear();
                foreach (var order in filtered)
                    Orders.Add(order);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
