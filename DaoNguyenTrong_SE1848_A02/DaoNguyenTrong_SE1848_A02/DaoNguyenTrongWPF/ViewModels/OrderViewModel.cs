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
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly IOrderRepository _orderRepository;

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set { _orders = value; OnPropertyChanged(); }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; OnPropertyChanged(); }
        }

        public OrderViewModel()
        {
            _orderRepository = new OrderRepository();
            LoadOrders();
        }

        public void LoadOrders()
        {
            Orders = new ObservableCollection<Order>(_orderRepository.GetAll());
        }

        public void AddOrder(Order order)
        {
            _orderRepository.Add(order);
            Orders.Add(order);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            _orderRepository.Update(updatedOrder);
            var oldOrder = Orders.FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
            if (oldOrder != null)
            {
                int index = Orders.IndexOf(oldOrder);
                Orders[index] = updatedOrder;
            }
        }

        public void DeleteOrder(int orderId)
        {
            _orderRepository.Delete(orderId);
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order != null)
                Orders.Remove(order);
        }

        public void SearchOrders(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadOrders();
            }
            else
            {
                var filtered = _orderRepository.GetAll()
                    .Where(o => (o.CustomerId != null && o.CustomerId.ToString().Contains(keyword))
                             || (o.EmployeeId != null && o.EmployeeId.ToString().Contains(keyword))
                             || (o.OrderDate != null && o.OrderDate.ToString().Contains(keyword)));
                Orders = new ObservableCollection<Order>(filtered);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
