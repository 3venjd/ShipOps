using System;
using System.Collections.Generic;
using System.Text;

namespace ShipOps.Common.Models
{
    public class VoyResponse
    {
        public int Id { get; set; }

        public int Voy_number { get; set; }

        public string Account { get; set; }

        public string Laycan { get; set; }

        public string Contract { get; set; }

        public string Cargo { get; set; }

        public string Sf { get; set; }

        public string Pol { get; set; }

        public string Facility { get; set; }

        public string Pod { get; set; }

        public string Cargo_Charterer { get; set; }

        public string Owner_Charterer { get; set; }

        public string Shipper { get; set; }

        public string Consignee { get; set; }

        public double Latitude { get; set; }

        public double Altitude { get; set; }

        public DateTime LastKnowPosition { get; set; }

        public DateTime LastKnowPositionLocal => LastKnowPosition.ToLocalTime();

        public DateTime Eta { get; set; }

        public DateTime EtaLocal => Eta.ToLocalTime();

        public DateTime Etb { get; set; }

        public DateTime EtbLocal => Etb.ToLocalTime();

        public DateTime Etc { get; set; }

        public DateTime EtcLocal => Etc.ToLocalTime();

        public DateTime Etd { get; set; }

        public DateTime EtdLocal => Etd.ToLocalTime();

        public UserResponse Employee { get; set; }

        public PortResponse Port { get; set; }

        public VesselResponse Vessel { get; set; }

        public List<StatusResponse> Statuses { get; set; }

        public List<VoyImageResponse> Voyimages { get; set; }

        public List<OpinionResponse> Opinions { get; set; }

        public List<TripDetailResponse> TripDetails { get; set; }
    }
}
