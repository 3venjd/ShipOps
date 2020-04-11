using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class TripDetailResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        public double Latitude { get; set; }

        public double Altitude { get; set; }
    }
}
