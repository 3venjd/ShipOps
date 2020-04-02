using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class OfficeEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Postal_Code { get; set; }


        [Required(ErrorMessage = "the field {0} is required")]
        public string Phone { get; set; }

        public string Usa_Phone { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Email { get; set; }

        public ICollection<UserEntity> Employees { get; set; }
    }
}
