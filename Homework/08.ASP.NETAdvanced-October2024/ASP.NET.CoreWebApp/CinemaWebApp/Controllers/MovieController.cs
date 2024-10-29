using CinemaWebApp.Data;
using CinemaWebApp.Data.Models;
using CinemaWebApp.ViewModels.Cinema;
using CinemaWebApp.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
    public class MovieController(AppDbContext context) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<Movie> movies = await context.Movies.ToListAsync();

			var movieIndexViewModels = movies
				.Where(m => m.IsDeleted == false)
				.Select(m => new MovieIndexViewModel()
				{
					Id = m.Id,
					Title = m.Title,
					Genre = m.Genre,
					ReleaseDate = m.ReleaseDate,
					Duration = m.Duration
				});

			return View(movieIndexViewModels);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View(new MovieViewModel());
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(MovieViewModel viewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(viewModel);
			}

			var movie = new Movie()
			{
				Title = viewModel.Title,
				Genre = viewModel.Genre,
				ReleaseDate = viewModel.ReleaseDate,
				Director = viewModel.Director,
				Duration = viewModel.Duration,
				Description = viewModel.Description,
				ImageUrl = viewModel.ImageUrl,
				IsDeleted = false
			};

			await context.Movies.AddAsync(movie);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int movieId)
		{
			Movie? movie = await context.Movies.FindAsync(movieId);

			if (movie == null)
			{
				return NotFound();
			}

			var viewModel = new MovieViewModel()
			{
				Title = movie.Title,
				Genre = movie.Genre,
				ReleaseDate = movie.ReleaseDate,
				Director = movie.Director,
				Duration = movie.Duration,
				Description = movie.Description
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Remove(int movieId)
		{
			Movie? movie = await context.Movies.FindAsync(movieId);

			if (movie == null)
			{
				return NotFound();
			}

			movie.IsDeleted = true;

			var existingAssignments = await context.CinemasMovies
				.Where(cm => cm.MovieId == movieId)
				.ToListAsync();

			context.RemoveRange(existingAssignments);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> AddToProgram(int movieId)
		{
			var movie = await context.Movies.FindAsync(movieId);

			if (movie == null)
			{
				return RedirectToAction(nameof(Index));
			}

			var cinemas = await context.Cinemas
				.Include(c => c.CinemaMovies)
				.ThenInclude(cm => cm.Movie)
				.ToListAsync();

			var viewModel = new AddMovieToCinemaProgramViewModel()
			{
				MovieId = movie.Id,
				MovieTitle = movie.Title,
				Cinemas = cinemas
					.Where(c => c.IsDeleted == false)
					.Select(c => new CinemaCheckBoxItem()
					{
						Id = c.Id,
						Name = c.Name,
						Location = c.Location,
						IsSelected = c.CinemaMovies
							.Any(cm => cm.MovieId == movieId)
					}).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddToProgram(AddMovieToCinemaProgramViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var existingAssignments = await context.CinemasMovies
				.Where(cm => cm.MovieId == model.MovieId)
				.ToListAsync();

			context.RemoveRange(existingAssignments);

			foreach (var cinema in model.Cinemas)
			{
				if (cinema.IsSelected)
				{
					var cinemaMovie = new CinemaMovie()
					{
						CinemaId = cinema.Id,
						MovieId = model.MovieId
					};

					await context.CinemasMovies.AddAsync(cinemaMovie);
				}
			}

			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}
