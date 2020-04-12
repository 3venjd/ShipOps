using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class TerminalResponse
    {
        public int Id { get; set; }

        public string Terminal_Name { get; set; }

        public string Max_Loa { get; set; }

        public string Max_Beam { get; set; }

        public string Max_Draft { get; set; }

        public string Displacement { get; set; }

        public string Water_Density { get; set; }

        public string Working_hours { get; set; }

        public string Type_Cargo { get; set; }

        public string ImageUrl { get; set; }

        //TODO: Change Path
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://shipops.azurewebsites.net{ImageUrl.Substring(1)}";

        public List<LineUpResponse> LineUps { get; set; }
    }
}
