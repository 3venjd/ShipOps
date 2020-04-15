using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipOps.Prism.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public HomePageViewModel(INavigationService navigationService ) : base(navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
