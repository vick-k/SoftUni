using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApp.Data.Models
{
    public class CinemaMovie
    {
        [ForeignKey(nameof(Cinema))]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
    }
}
