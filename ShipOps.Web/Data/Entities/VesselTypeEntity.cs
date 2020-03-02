using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class VesselTypeEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(20, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Type_Vessel { get; set; }

        public ICollection<VesselEntity> Vessels { get; set; }
    }
}
