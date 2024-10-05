﻿using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<Movie> Movies { get; set; }

		public DbSet<Cinema> Cinemas { get; set; }

		public DbSet<CinemaMovie> CinemasMovies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<CinemaMovie>()
				.HasKey(cm => new { cm.CinemaId, cm.MovieId });
		}
	}
}
