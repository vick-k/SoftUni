using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaWebApp.Data.Models
{
    public class UserMovie
    {
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual ApplicationUser User { get; set; } = null!;

        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
    }
}
