using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models.Data
{
	public class AppDbContext : IdentityDbContext<IdentityUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Cinema> Cinemas { get; set; }

		public DbSet<CinemaMovie> CinemasMovies { get; set; }

		public DbSet<UserMovie> UsersMovies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CinemaMovie>()
				.HasKey(cm => new { cm.CinemaId, cm.MovieId });

			modelBuilder.Entity<UserMovie>()
				.HasKey(um => new { um.UserId, um.MovieId });
		}
	}
}
