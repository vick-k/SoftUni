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
        public async Task<IActionResult> Index()
        {
            List<Cinema> cinemas = await context.Cinemas.ToListAsync();

            var cinemaIndexViewModels = cinemas
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
    }
}
