using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class AlertImageResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://MEU.azurewebsites.net{ImageUrl.Substring(1)}";

    }
}
