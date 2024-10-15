using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels.Cinema
{
    public class CinemaCreateViewModel
    {
        [Required(ErrorMessage = "Cinema name is required.")]
        [StringLength(80, ErrorMessage = "Cinema name cannot be longer than 80 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(50, ErrorMessage = "Location cannot be longer than 50 characters.")]
        public string Location { get; set; } = null!;
    }
}
