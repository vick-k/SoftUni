using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Data.Models
{
    public class Cinema
    {
        public int Id { get; set; }

        [MaxLength(80)]
        public string Name { get; set; } = null!;

        [MaxLength(100)]
        public string Location { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
    }
}
