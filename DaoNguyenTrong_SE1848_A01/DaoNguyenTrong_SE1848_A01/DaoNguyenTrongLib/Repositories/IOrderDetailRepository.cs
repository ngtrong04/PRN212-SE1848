using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;

namespace DaoNguyenTrongLib.Repositories
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        IEnumerable<OrderDetail> GetByOrderId(int orderId);
        void Add(OrderDetail orderDetail);
        void Update(OrderDetail orderDetail);
        void Delete(int orderId, int productId);
    }
}
