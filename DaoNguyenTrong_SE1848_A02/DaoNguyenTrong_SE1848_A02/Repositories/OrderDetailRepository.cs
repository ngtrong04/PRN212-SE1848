using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly LucySalesDataContext _context;

        public OrderDetailRepository(LucySalesDataContext context)
        {
            _context = context;
        }

        public OrderDetailRepository()
        {
            _context = new LucySalesDataContext();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .ToList();
        }

        public OrderDetail? GetById(int orderId, int productId)
        {
            return _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
        }

        public void Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();
        }

        public void Update(OrderDetail orderDetail)
        {
            var existing = _context.OrderDetails
                .FirstOrDefault(od => od.OrderId == orderDetail.OrderId && od.ProductId == orderDetail.ProductId);
            if (existing != null)
            {
                existing.UnitPrice = orderDetail.UnitPrice;
                existing.Quantity = orderDetail.Quantity;
                existing.Discount = orderDetail.Discount;
                _context.SaveChanges();
            }
        }

        public void Delete(int orderId, int productId)
        {
            var existing = _context.OrderDetails
                .FirstOrDefault(od => od.OrderId == orderId && od.ProductId == productId);
            if (existing != null)
            {
                _context.OrderDetails.Remove(existing);
                _context.SaveChanges();
            }
        }

        public IEnumerable<OrderDetail> GetByOrderId(int orderId)
        {
            return _context.OrderDetails
                .Include(od => od.Product)
                .Where(od => od.OrderId == orderId)
                .ToList();
        }
    }
}
