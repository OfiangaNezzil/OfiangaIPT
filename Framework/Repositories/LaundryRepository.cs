using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain.Models;
using Framework.Data;
using System.Collections.Generic;
using System.Data;

namespace Framework.Repositories
{
    public class LaundryRepository : ILaundryRepository
    {
        private readonly AppDbContext _context;

        public LaundryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<LaundryOrder> GetAll()
        {
            using var connection = _context.CreateConnection();
            return connection.Query<LaundryOrder>(
                "GetAllOrders",
                commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<LaundryOrder> Search(string keyword)
        {
            using var connection = _context.CreateConnection();
            return connection.Query<LaundryOrder>(
                "SearchOrders",
                new { Keyword = keyword },
                commandType: CommandType.StoredProcedure);
        }

        public void Add(LaundryOrder order)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "AddOrder",
                order,
                commandType: CommandType.StoredProcedure);
        }

        public void Update(LaundryOrder order)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "UpdateOrder",
                order,
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(string orderId)
        {
            using var connection = _context.CreateConnection();
            connection.Execute(
                "DeleteOrder",
                new { OrderId = orderId },
                commandType: CommandType.StoredProcedure);
        }
    }
}
