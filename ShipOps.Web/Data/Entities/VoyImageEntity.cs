using System.ComponentModel.DataAnnotations;

namespace ShipOps.Web.Data.Entities
{
    public class VoyImageEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "the field {0} is required")]
        public string Title { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //TODO: Change Path
        [Display(Name = "Image")]
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl) ? null : $"https://shipops.azurewebsites.net{ImageUrl.Substring(1)}";

        public VoyEntity Voy { get; set; }
    }
}
