using CinemaWebApp.ViewModels.Movie;

namespace CinemaWebApp.ViewModels.Cinema
{
    public class CinemaDetailsViewModel
    {
        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public List<MovieProgramViewModel> Movies { get; set; } = new List<MovieProgramViewModel>();
    }
}
