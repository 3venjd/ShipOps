using System.Collections.Generic;

namespace ShipOps.Common.Models
{
    public class PortResponse
    {
        public int Id { get; set; }
        
        public string Port_Name { get; set; }

        public string ImageUrl { get; set; }

        //TODO: Change Path
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://shipops.azurewebsites.net{ImageUrl.Substring(1)}";

        public List<TerminalResponse> Terminals { get; set; }
    }
}
