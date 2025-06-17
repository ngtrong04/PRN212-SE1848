using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetAllOrders() => _orderRepository.GetAll();

        public Order GetOrderById(int id) => _orderRepository.GetById(id);

        public void AddOrder(Order order) => _orderRepository.Add(order);

        public void UpdateOrder(Order order) => _orderRepository.Update(order);

        public void DeleteOrder(int id) => _orderRepository.Delete(id);

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId) => _orderRepository.GetOrdersByCustomerId(customerId);

        public IEnumerable<Order> GetOrdersByEmployeeId(int employeeId) => _orderRepository.GetOrdersByEmployeeId(employeeId);
    }
}
