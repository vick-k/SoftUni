using CinemaWebApp.Data;
using CinemaWebApp.Data.Models;
using CinemaWebApp.ViewModels.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace CinemaWebApp.Controllers
{
    [Authorize]
    public class WatchlistController(AppDbContext context, UserManager<ApplicationUser> userManager) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User);

            var watchlistMovies = await context.UsersMovies
                .Where(um => um.UserId == userId)
                .Where(um => um.Movie.IsDeleted == false)
                .Include(um => um.Movie)
                .Select(um => new WatchlistViewModel()
                {
                    MovieId = um.MovieId,
                    Title = um.Movie.Title,
                    Genre = um.Movie.Genre,
                    ReleaseDate = um.Movie.ReleaseDate.ToString("MMMM yyyy", CultureInfo.InvariantCulture),
                    ImageUrl = um.Movie.ImageUrl != string.Empty ? um.Movie.ImageUrl : "/images/no-movie-image.png"
                })
                .ToListAsync();

            return View(watchlistMovies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWatchlist(int movieId)
        {
            var userId = userManager.GetUserId(User);

            var userMovie = await context.UsersMovies
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == movieId);

            if (userMovie == null)
            {
                userMovie = new UserMovie()
                {
                    UserId = userId!,
                    MovieId = movieId
                };

                await context.UsersMovies.AddAsync(userMovie);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index), nameof(MovieController).Replace("Controller", ""));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromWatchlist(int movieId)
        {
            var userId = userManager.GetUserId(User);

            var userMovie = await context.UsersMovies
                .FirstOrDefaultAsync(um => um.UserId == userId && um.MovieId == movieId);

            if (userMovie != null)
            {
                context.UsersMovies.Remove(userMovie);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
