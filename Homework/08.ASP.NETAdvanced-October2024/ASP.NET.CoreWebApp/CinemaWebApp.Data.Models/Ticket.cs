using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApp.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Cinema))]
        public int CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
