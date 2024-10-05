using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.ViewModels.Cinema
{
    public class CinemaIndexViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
    }
}
