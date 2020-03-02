using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class NewEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(50, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePublication { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DatePublicationLocal => DatePublication.ToLocalTime();

        public ICollection<NewImageEntity> NewImages { get; set; }
    }
}
