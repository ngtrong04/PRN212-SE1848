using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using Repositories;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Order> GetAll() => _repository.GetAll();
        public Order? GetById(int id) => _repository.GetById(id);
        public void Add(Order order) => _repository.Add(order);
        public void Update(Order order) => _repository.Update(order);
        public void Delete(int id) => _repository.Delete(id);
        public IEnumerable<Order> Search(string keyword) => _repository.Search(keyword);
    }
}
