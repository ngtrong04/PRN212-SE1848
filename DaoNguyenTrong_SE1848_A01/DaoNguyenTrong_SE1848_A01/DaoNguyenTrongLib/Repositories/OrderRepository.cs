using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<Order> GetAll() => _context.Orders;

        public Order GetById(int id) => _context.Orders.FirstOrDefault(o => o.OrderID == id);

        public void Add(Order order)
        {
            order.OrderID = (_context.Orders.Count > 0)
                ? _context.Orders.Max(o => o.OrderID) + 1
                : 1;
            _context.Orders.Add(order);
        }

        public void Update(Order order)
        {
            var existing = GetById(order.OrderID);
            if (existing != null)
            {
                existing.CustomerID = order.CustomerID;
                existing.EmployeeID = order.EmployeeID;
                existing.OrderDate = order.OrderDate;
            }
        }

        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
                _context.Orders.Remove(order);
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders.Where(o => o.CustomerID == customerId);
        }

        public IEnumerable<Order> GetOrdersByEmployeeId(int employeeId)
        {
            return _context.Orders.Where(o => o.EmployeeID == employeeId);
        }

        
    }
}
