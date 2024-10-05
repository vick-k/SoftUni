using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels.Movie
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            ReleaseDate = DateTime.Today;
        }

        [Required(ErrorMessage = "Movie title is required.")]
        [StringLength(150, ErrorMessage = "Movie title cannot be longer than 150 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(100, ErrorMessage = "Genre cannot be longer than 100 characters.")]
        public string Genre { get; set; } = null!;

        [Required(ErrorMessage = "Release date is required.")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Director name is required.")]
        [StringLength(80, ErrorMessage = "Director name cannot be longer than 80 characters.")]
        public string Director { get; set; } = null!;

        [Required(ErrorMessage = "Please specify the movie duration.")]
        [Range(1, 600, ErrorMessage = "Duration must be between 1 and 600 minutes.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(600, ErrorMessage = "Description cannot be longer than 600 characters.")]
        public string Description { get; set; } = null!;
    }
}
