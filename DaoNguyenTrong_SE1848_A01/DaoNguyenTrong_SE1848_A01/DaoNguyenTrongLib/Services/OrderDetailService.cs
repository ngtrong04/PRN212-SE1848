using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaoNguyenTrongLib.Models;
using DaoNguyenTrongLib.Repositories;

namespace DaoNguyenTrongLib.Services
{
    public class OrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public IEnumerable<OrderDetail> GetAllOrderDetails() => _orderDetailRepository.GetAll();

        public IEnumerable<OrderDetail> GetOrderDetailsByOrderId(int orderId) => _orderDetailRepository.GetByOrderId(orderId);

        public void AddOrderDetail(OrderDetail orderDetail) => _orderDetailRepository.Add(orderDetail);

        public void UpdateOrderDetail(OrderDetail orderDetail) => _orderDetailRepository.Update(orderDetail);

        public void DeleteOrderDetail(int orderId, int productId) => _orderDetailRepository.Delete(orderId, productId);
    }
}
