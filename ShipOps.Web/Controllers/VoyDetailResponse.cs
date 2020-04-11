using ShipOps.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Controllers
{
    public class VoyDetailResponse
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime DateLocal => Date.ToLocalTime();

        public double Latitude { get; set; }

        public double Altitude { get; set; }

        public VoyResponse Voy { get; set; }
    }
}
