using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context = DataContext.Instance;

        public IEnumerable<OrderDetail> GetAll() => _context.OrderDetails;

        public IEnumerable<OrderDetail> GetByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderID == orderId);
        }

        public void Add(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
        }

        public void Update(OrderDetail orderDetail)
        {
            var existing = _context.OrderDetails
                .FirstOrDefault(od => od.OrderID == orderDetail.OrderID && od.ProductID == orderDetail.ProductID);
            if (existing != null)
            {
                existing.UnitPrice = orderDetail.UnitPrice;
                existing.Quantity = orderDetail.Quantity;
                existing.Discount = orderDetail.Discount;
            }
        }

        public void Delete(int orderId, int productId)
        {
            var od = _context.OrderDetails.FirstOrDefault(o => o.OrderID == orderId && o.ProductID == productId);
            if (od != null)
                _context.OrderDetails.Remove(od);
        }
    }
}
