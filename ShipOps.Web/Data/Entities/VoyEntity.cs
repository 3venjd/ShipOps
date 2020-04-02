using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class VoyEntity
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "the field {0} is required")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "the {0} field must have {1} numbers")]
        public int Voy_number { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Account { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Laycan { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Contract { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Sf { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Pol { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Facility { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Pod { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Cargo_Charterer { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Owner_Charterer { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Shipper { get; set; }

        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        [Required(ErrorMessage = "the field {0} is required")]
        public string Consignee { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public double Latitude { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public double Altitude { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastKnowPosition { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastKnowPositionLocal => LastKnowPosition.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Eta { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = false)]
        public DateTime EtaLocal => Eta.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM}", ApplyFormatInEditMode = true)]
        public DateTime Etb { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtbLocal => Etb.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etc { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtcLocal => Etc.ToLocalTime();

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Etd { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EtdLocal => Etd.ToLocalTime();

        public CompanyEntity Company { get; set; }

        public UserEntity Employee { get; set; }

        public PortEntity Port { get; set; }

        public VesselEntity Vessel { get; set; }

        public ICollection<StatusEntity> Statuses { get; set; }

        public ICollection<VoyImageEntity> Voyimages { get; set; }

        public ICollection<OpinionEntity> Opinions { get; set; }

        public ICollection<TripDetailEntity> TripDetails { get; set; }
    }
}
