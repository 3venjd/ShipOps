﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipOps.Prism.ViewModels
{
    public class VesselsPageViewModel : ViewModelBase
    {
        public VesselsPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
