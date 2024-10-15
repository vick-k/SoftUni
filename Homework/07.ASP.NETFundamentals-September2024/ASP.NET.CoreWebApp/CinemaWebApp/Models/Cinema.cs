using System.ComponentModel.DataAnnotations;

namespace CinemaWebApp.Models
{
	public class Cinema
	{
		public int Id { get; set; }

		[MaxLength(80)]
		public string Name { get; set; } = null!;

		[MaxLength(100)]
		public string Location { get; set; } = null!;

		public bool IsDeleted { get; set; }

		public ICollection<CinemaMovie> CinemaMovies { get; set; } = new List<CinemaMovie>();
	}
}
