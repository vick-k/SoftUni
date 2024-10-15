namespace CinemaWebApp.ViewModels.Cinema
{
    public class CinemaCheckBoxItem
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public bool IsSelected { get; set; }
    }
}
