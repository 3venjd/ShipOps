using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipOps.Prism.ViewModels
{
    public class VoysPageViewModel : ViewModelBase
    {
        public VoysPageViewModel(INavigationService navigationService ) : base(navigationService)
        {
            Title = "Voys Detail";
        }
    }
}
