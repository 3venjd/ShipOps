using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShipOps.Web.Data.Entities
{
    public class PortEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        [MaxLength(20, ErrorMessage = "the {0} field can no have more than {1} characters.")]
        public string Port_Name { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://shipops.azurewebsites.net{ImageUrl.Substring(1)}";

        public ICollection<VoyEntity> Voys { get; set; }

        public ICollection<TerminalEntity> Terminals { get; set; }
    }
}
