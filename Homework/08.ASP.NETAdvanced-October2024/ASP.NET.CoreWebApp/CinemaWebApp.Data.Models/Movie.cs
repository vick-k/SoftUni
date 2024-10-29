using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Data.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Title { get; set; } = null!;

        [MaxLength(100)]
        public string Genre { get; set; } = null!;

        [Required]
        public DateTime ReleaseDate { get; set; }

        [MaxLength(80)]
        public string Director { get; set; } = null!;

        public int Duration { get; set; }

        [MaxLength(600)]
        public string Description { get; set; } = null!;

        [MaxLength(2083)]
        public string ImageUrl { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();

        public virtual ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();
    }
}
