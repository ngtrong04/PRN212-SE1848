using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LucySalesDataContext _context;

        public OrderRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        // Sửa lại constructor không tham số để khởi tạo context
        public OrderRepository()
        {
            _context = new LucySalesDataContext();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .ToList();
        }

        public Order? GetById(int id)
        {
            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.OrderId == id);
        }

        // BỔ SUNG: Lấy danh sách đơn hàng theo CustomerId
        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void Update(Order order)
        {
            var existing = _context.Orders.Find(order.OrderId);
            if (existing != null)
            {
                existing.CustomerId = order.CustomerId;
                existing.EmployeeId = order.EmployeeId;
                existing.OrderDate = order.OrderDate;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return GetAll();

            keyword = keyword.ToLower();

            return _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Where(o =>
                    (!string.IsNullOrEmpty(o.Customer.CompanyName) && o.Customer.CompanyName.ToLower().Contains(keyword))
                 || (!string.IsNullOrEmpty(o.Employee.Name) && o.Employee.Name.ToLower().Contains(keyword))
                 || o.OrderDate.ToString().Contains(keyword)
                )
                .ToList();
        }
    }
}