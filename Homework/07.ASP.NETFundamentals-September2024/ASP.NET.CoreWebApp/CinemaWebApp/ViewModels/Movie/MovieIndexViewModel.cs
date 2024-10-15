namespace CinemaWebApp.ViewModels.Movie
{
    public class MovieIndexViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Genre { get; set; } = null!;

        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }
    }
}
