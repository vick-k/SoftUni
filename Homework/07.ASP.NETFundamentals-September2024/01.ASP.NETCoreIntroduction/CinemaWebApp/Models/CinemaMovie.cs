using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApp.Models
{
	public class CinemaMovie
	{
		[ForeignKey(nameof(Cinema))]
		public int CinemaId { get; set; }

		public Cinema Cinema { get; set; } = null!;

		[ForeignKey(nameof(Movie))]
		public int MovieId { get; set; }

		public Movie Movie { get; set; } = null!;
	}
}
