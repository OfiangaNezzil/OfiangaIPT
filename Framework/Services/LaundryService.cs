using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Repositories;
using System.Collections.Generic;

namespace Framework.Services
{
    public class LaundryService : ILaundryService
    {
        private readonly ILaundryRepository _repository;

        public LaundryService(ILaundryRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<LaundryOrder> GetOrders()
            => _repository.GetAll();

        public IEnumerable<LaundryOrder> SearchOrders(string keyword)
            => _repository.Search(keyword);

        public void CreateOrder(LaundryOrder order)
        {
            if (string.IsNullOrWhiteSpace(order.CustomerName))
                throw new System.Exception("Customer name is required");

            _repository.Add(order);
        }

        public void EditOrder(LaundryOrder order)
            => _repository.Update(order);

        public void RemoveOrder(string orderId)
            => _repository.Delete(orderId);
    }
}