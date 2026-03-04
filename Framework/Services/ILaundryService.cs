using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Collections.Generic;

namespace Framework.Services
{
    public interface ILaundryService
    {
        IEnumerable<LaundryOrder> GetOrders();
        IEnumerable<LaundryOrder> SearchOrders(string keyword);
        void CreateOrder(LaundryOrder order);
        void EditOrder(LaundryOrder order);
        void RemoveOrder(string orderId);
    }
}
