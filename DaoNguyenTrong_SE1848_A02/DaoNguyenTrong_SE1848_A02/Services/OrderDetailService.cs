using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _repository;

        public OrderDetailService(IOrderDetailRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<OrderDetail> GetAll() => _repository.GetAll();
        public OrderDetail? GetById(int orderId, int productId) => _repository.GetById(orderId, productId);
        public void Add(OrderDetail orderDetail) => _repository.Add(orderDetail);
        public void Update(OrderDetail orderDetail) => _repository.Update(orderDetail);
        public void Delete(int orderId, int productId) => _repository.Delete(orderId, productId);
        public IEnumerable<OrderDetail> GetByOrderId(int orderId) => _repository.GetByOrderId(orderId);
    }
}
