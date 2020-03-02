using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class OpinionEntity
    {
        public int Id { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "You must Select a Vessel Type")]
        public float Qualification { get; set; }

        public string Description { get; set; }

        public VoyEntity Voy { get; set; }

    }
}
