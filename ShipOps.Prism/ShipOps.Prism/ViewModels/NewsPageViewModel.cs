﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipOps.Prism.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        public NewsPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
