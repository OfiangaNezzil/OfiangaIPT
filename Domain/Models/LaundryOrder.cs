using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    public class LaundryOrder
    {
        public string OrderId { get; set; }
        public string ContactNumber { get; set; }
        public string CustomerName { get; set; }
        public string ServiceType { get; set; }
        public decimal WeightInKg { get; set; }
        public decimal TotalPrice { get; set; }
    }
}