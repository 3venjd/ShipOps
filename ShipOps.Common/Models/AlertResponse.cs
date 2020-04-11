using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class AlertResponse
    {
        public int Id { get; set; }

        public string Alert_Description { get; set; }

        public DateTime Alert_Date { get; set; }

        public DateTime Alert_DateLocal => Alert_Date.ToLocalTime();

        public List<AlertImageResponse> AlertImages { get; set; }
    }
}
