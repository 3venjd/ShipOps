using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class VoyImageResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        //TODO: Change Path
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://shipops.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
