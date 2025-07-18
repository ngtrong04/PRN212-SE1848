using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        OrderDetail? GetById(int orderId, int productId);
        void Add(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(int orderId, int productId);
        IEnumerable<OrderDetail> GetByOrderId(int orderId);
    }
}
