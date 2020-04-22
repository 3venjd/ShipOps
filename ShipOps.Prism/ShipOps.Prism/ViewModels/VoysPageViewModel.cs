using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ShipOps.Common.Models;
using ShipOps.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipOps.Prism.ViewModels
{
    public class VoysPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private CompanyResponse _company;
        private DelegateCommand _checkCompanyCommand;

        public VoysPageViewModel(INavigationService navigationService, IApiService apiService ) : base(navigationService)
        {
            Title = "Voys";
            _apiService = apiService;
            CheckCompanyAsync();
        }

        public CompanyResponse Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }

        public string Company_name { get; set; }

        //public DelegateCommand CheckCompanyCommand => _checkCompanyCommand ?? (_checkCompanyCommand = new DelegateCommand(CheckCompanyAsync));

        private async void CheckCompanyAsync()
        {
            if (string.IsNullOrEmpty("Hyundai"))
            {
                await App.Current.MainPage.DisplayAlert(
                        "Error",
                        "the company doesn´t exist",
                        "Accept"
                    );
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetCompanyAsync("Hyundai", url,"api","/Companies");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                        "Error",
                        response.Message,
                        "Accept"
                    );
            }

            Company = (CompanyResponse)response.Result;
        }
    }
}
