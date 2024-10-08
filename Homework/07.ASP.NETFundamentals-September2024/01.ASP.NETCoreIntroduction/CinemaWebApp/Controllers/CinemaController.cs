using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using CinemaWebApp.ViewModels.Cinema;
using CinemaWebApp.ViewModels.Movie;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Controllers
{
	public class CinemaController(AppDbContext context) : Controller
	{
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<Cinema> cinemas = await context.Cinemas.ToListAsync();

			var cinemaIndexViewModels = cinemas
				.Where(c => c.IsDeleted == false)
				.Select(c => new CinemaIndexViewModel()
				{
					Id = c.Id,
					Name = c.Name,
					Location = c.Location
				});

			return View(cinemaIndexViewModels);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CinemaCreateViewModel cinemaCreateViewModel)
		{
			if (!ModelState.IsValid)
			{
				return View(cinemaCreateViewModel);
			}

			var cinema = new Cinema()
			{
				Name = cinemaCreateViewModel.Name,
				Location = cinemaCreateViewModel.Location
			};

			await context.Cinemas.AddAsync(cinema);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var cinema = await context.Cinemas
				.Include(c => c.CinemaMovies)
				.ThenInclude(cm => cm.Movie)
				.FirstOrDefaultAsync(c => c.Id == id);

			if (cinema == null)
			{
				return RedirectToAction(nameof(Index));
			}

			var cinemaDetailsViewModel = new CinemaDetailsViewModel()
			{
				Name = cinema.Name,
				Location = cinema.Location,
				Movies = cinema.CinemaMovies
					.Select(cm => new MovieProgramViewModel()
					{
						Title = cm.Movie.Title,
						Duration = cm.Movie.Duration
					}).ToList()
			};

			return View(cinemaDetailsViewModel);
		}

		[HttpGet]
		public async Task<IActionResult> Remove(int id)
		{
			var cinema = await context.Cinemas
				.FirstOrDefaultAsync(c => c.Id == id);

			if (cinema == null)
			{
				return RedirectToAction(nameof(Index));
			}

			var cinemaIndexViewModel = new CinemaIndexViewModel()
			{
				Name = cinema.Name,
				Location = cinema.Location
			};

			return View(cinemaIndexViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Remove(CinemaIndexViewModel viewModel)
		{
			var cinema = await context.Cinemas
				.FirstOrDefaultAsync(c => c.Id == viewModel.Id);

			if (cinema == null)
			{
				return NotFound();
			}

			cinema.IsDeleted = true;

			var existingAssignments = await context.CinemasMovies
				.Where(cm => cm.CinemaId == viewModel.Id)
				.ToListAsync();

			context.RemoveRange(existingAssignments);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}
