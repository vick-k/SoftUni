using Microsoft.AspNetCore.Identity;

namespace CinemaWebApp.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

        public virtual ICollection<UserMovie> UserMovies { get; set; } = new List<UserMovie>();
    }
}
