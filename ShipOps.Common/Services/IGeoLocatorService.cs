﻿using System.Threading.Tasks;

namespace ShipOps.Common.Services
{
    public interface IGeoLocatorService
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task GetLocationAsync();
    }
}
