using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Framework.Services;
using LaundryManagement.Commands;
using System.Collections.ObjectModel;

namespace LaundryManagement.ViewModels
{
    public class HomeLaundryViewModel : BaseViewModel
    {
        private readonly ILaundryService _service;
        private readonly MainViewModel _main;

        public ObservableCollection<LaundryOrder> Orders { get; set; }

        public LaundryOrder SelectedOrder { get; set; }

        public string SearchText { get; set; }

        public RelayCommand SearchCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand UpdateCommand { get; }
        public RelayCommand OpenAddCommand { get; }

        public HomeLaundryViewModel(ILaundryService service, MainViewModel main)
        {
            _service = service;
            _main = main;

            Orders = new ObservableCollection<LaundryOrder>(_service.GetOrders());

            SearchCommand = new RelayCommand(_ => Search());
            DeleteCommand = new RelayCommand(_ => Delete());
            UpdateCommand = new RelayCommand(_ => Update());
            OpenAddCommand = new RelayCommand(_ => _main.OpenAddCommand.Execute(null));
        }

        private void Search()
        {
            var result = _service.SearchOrders(SearchText);
            Orders.Clear();
            foreach (var order in result)
                Orders.Add(order);
        }

        private void Delete()
        {
            if (SelectedOrder == null) return;

            _service.RemoveOrder(SelectedOrder.OrderId);
            Orders.Remove(SelectedOrder);
        }

        private void Update()
        {
            if (SelectedOrder == null) return;

            _service.EditOrder(SelectedOrder);
        }
    }
}
