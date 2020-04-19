using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShipOps.Common.Services;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ShipOps.Prism.Views
{
    public partial class VoysDetailsPage : ContentPage
    {
        private readonly IGeoLocatorService _geoLocatorService;

        public VoysDetailsPage(IGeoLocatorService geoLocatorService)
        {
            InitializeComponent();
            _geoLocatorService = geoLocatorService;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MoveMapToCurrentPositionAsycn();
        }

        private async void MoveMapToCurrentPositionAsycn()
        {
            bool isLocationPermision = await CheckLocationPermisionsAsync();

            if (isLocationPermision)
            {
                MapView.IsShowingUser = true;

                await _geoLocatorService.GetLocationAsync();
                if (_geoLocatorService.Latitude != 0 && _geoLocatorService.Longitude != 0)
                {
                    Position position = new Position
                        (
                            _geoLocatorService.Latitude,
                            _geoLocatorService.Longitude
                        );
                    MapView.MoveToRegion(MapSpan.FromCenterAndRadius
                        (
                        position,
                        Distance.FromKilometers(.5)));
                }
            }
        }

        private async Task<bool> CheckLocationPermisionsAsync()
        {
            PermissionStatus permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            PermissionStatus permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            PermissionStatus permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            bool isLocationEnabled = permissionLocation == PermissionStatus.Granted ||
                                     permissionLocationAlways == PermissionStatus.Granted ||
                                     permissionLocationWhenInUse == PermissionStatus.Granted;

            if (isLocationEnabled)
            {
                return true;
            }


            await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);

            permissionLocation = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            permissionLocationAlways = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
            permissionLocationWhenInUse = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
            return permissionLocation == PermissionStatus.Granted ||
                                     permissionLocationAlways == PermissionStatus.Granted ||
                                     permissionLocationWhenInUse == PermissionStatus.Granted;


        }
    }
}
