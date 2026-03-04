using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Collections.Generic;

namespace Framework.Repositories
{
    public interface ILaundryRepository
    {
        IEnumerable<LaundryOrder> GetAll();
        IEnumerable<LaundryOrder> Search(string keyword);
        void Add(LaundryOrder order);
        void Update(LaundryOrder order);
        void Delete(string orderId);
    }
}