using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Services;
using LaundryManagement.Commands;

namespace LaundryManagement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _currentView;
        private readonly ILaundryService _service;

        public BaseViewModel CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenHomeCommand { get; }
        public RelayCommand OpenAddCommand { get; }

        public MainViewModel(ILaundryService service)
        {
            _service = service;

            OpenHomeCommand = new RelayCommand(_ => OpenHome());
            OpenAddCommand = new RelayCommand(_ => OpenAdd());

            OpenHome();
        }

        private void OpenHome()
        {
            CurrentView = new HomeLaundryViewModel(_service, this);
        }

        private void OpenAdd()
        {
            CurrentView = new AddLaundryViewModel(_service, this);
        }
    }
}
