using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Services;
using LaundryManagement.Commands;

namespace LaundryManagement.ViewModels
{
    public class AddLaundryViewModel : BaseViewModel
    {
        private readonly ILaundryService _service;
        private readonly MainViewModel _main;

        public string OrderId { get; set; }
        public string ContactNumber { get; set; }
        public string CustomerName { get; set; }
        public string ServiceType { get; set; }
        public decimal WeightInKg { get; set; }
        public decimal TotalPrice { get; set; }

        public RelayCommand SaveCommand { get; }
        public RelayCommand BackCommand { get; }

        public AddLaundryViewModel(ILaundryService service, MainViewModel main)
        {
            _service = service;
            _main = main;

            SaveCommand = new RelayCommand(_ => Save());
            BackCommand = new RelayCommand(_ => _main.OpenHomeCommand.Execute(null));
        }

        private void Save()
        {
            var order = new LaundryOrder
            {
                OrderId = OrderId,
                ContactNumber = ContactNumber,
                CustomerName = CustomerName,
                ServiceType = ServiceType,
                WeightInKg = WeightInKg,
                TotalPrice = TotalPrice
            };

            _service.CreateOrder(order);
            _main.OpenHomeCommand.Execute(null);
        }
    }
}
