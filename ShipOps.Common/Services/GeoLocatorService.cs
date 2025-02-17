﻿using Plugin.Geolocator;
using System;
using System.Threading.Tasks;

namespace ShipOps.Common.Services
{
    public class GeoLocatorService : IGeoLocatorService
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public async Task GetLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var location = await locator.GetPositionAsync();
                Latitude = location.Latitude;
                Longitude = location.Longitude;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
