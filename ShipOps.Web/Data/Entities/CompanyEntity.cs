using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public bool Pro { get; set; }

        public ICollection<UserEntity> Clients { get; set; }

        public ICollection<VoyEntity> Voys { get; set; }
    }
}
