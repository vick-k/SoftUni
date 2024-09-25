using CinemaWebApp.Models;
using CinemaWebApp.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApp.Controllers
{
	public class MovieController : Controller
	{
		private readonly AppDbContext _context;

		public MovieController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			List<Movie> movies = _context.Movies.ToList();

			return View(movies);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Movie movie)
		{
			if (ModelState.IsValid)
			{
				_context.Movies.Add(movie);
				_context.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(movie);
		}

		public IActionResult Details(int id)
		{
			Movie? movie = _context.Movies.Find(id);

			if (movie == null)
			{
				return NotFound();
			}

			return View(movie);
		}
	}
}
