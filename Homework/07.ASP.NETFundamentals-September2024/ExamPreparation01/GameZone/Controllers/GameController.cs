using GameZone.Data;
using GameZone.Data.Models;
using GameZone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static GameZone.Common.ValidationConstants;

namespace GameZone.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly GameZoneDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public GameController(GameZoneDbContext _context, UserManager<IdentityUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            List<Game> games = await context.Games
                .AsNoTracking()
                .Include(g => g.Genre)
                .Include(g => g.Publisher)
                .ToListAsync();

            var viewModels = games
                .Select(g => new GameAllViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Publisher = g.Publisher.UserName
                });

            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var genres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var viewModel = new GameAddViewModel()
            {
                Genres = genres
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GameAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string userId = userManager.GetUserId(User);

            var dateString = viewModel.ReleasedOn;

            if (!DateTime.TryParseExact(dateString, GameReleaseDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            var game = new Game()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                PublisherId = userId,
                ReleasedOn = parseDate,
                GenreId = viewModel.GenreId
            };

            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> MyZone()
        {
            var userId = userManager.GetUserId(User);

            var games = await context.GamersGames
                .AsNoTracking()
                .Where(gg => gg.GamerId == userId)
                .Include(gg => gg.Game)
                .Select(gg => new GameAllViewModel()
                {
                    Id = gg.GameId,
                    Title = gg.Game.Title,
                    ImageUrl = gg.Game.ImageUrl,
                    Genre = gg.Game.Genre.Name,
                    ReleasedOn = gg.Game.ReleasedOn.ToString(GameReleaseDateFormat),
                    Publisher = gg.Game.Publisher.UserName
                })
                .ToListAsync();

            return View(games);
        }

        [HttpGet]
        public async Task<IActionResult> AddToMyZone(int id)
        {
            var userId = userManager.GetUserId(User);

            var gamerGame = await context.GamersGames
                .FirstOrDefaultAsync(gg => gg.GamerId == userId && gg.GameId == id);

            if (gamerGame == null)
            {
                gamerGame = new GamerGame()
                {
                    GameId = id,
                    GamerId = userId
                };

                await context.GamersGames.AddAsync(gamerGame);
                await context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = userManager.GetUserId(User);

            var genres = await context.Genres
                .AsNoTracking()
                .Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();

            var game = await context.Games
                .FindAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            var model = new GameEditViewModel()
            {
                Title = game.Title,
                ImageUrl = game.ImageUrl,
                Description = game.Description,
                ReleasedOn = game.ReleasedOn.ToString(GameReleaseDateFormat),
                PublisherId = game.PublisherId,
                GenreId = game.GenreId,
                Genres = genres
            };

            if (model.PublisherId != userId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, GameEditViewModel viewModel)
        {
            var game = await context.Games
                .FindAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            string userId = userManager.GetUserId(User);

            if (game.PublisherId != userId)
            {
                return Unauthorized();
            }

            var dateString = viewModel.ReleasedOn;

            if (!DateTime.TryParseExact(dateString, GameReleaseDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                throw new InvalidOperationException("Invalid date format.");
            }

            game.Title = viewModel.Title;
            game.ImageUrl = viewModel.ImageUrl;
            game.Description = viewModel.Description;
            game.ReleasedOn = parseDate;
            game.GenreId = viewModel.GenreId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> StrikeOut(int id)
        {
            string userId = userManager.GetUserId(User);

            var gamerGame = await context.GamersGames
                .FirstOrDefaultAsync(gg => gg.GamerId == userId && gg.GameId == id);

            if (gamerGame != null)
            {
                context.GamersGames.Remove(gamerGame);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(MyZone));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Games
                .AsNoTracking()
                .Where(g => g.Id == id)
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    ImageUrl = g.ImageUrl,
                    Description = g.Description,
                    Genre = g.Genre.Name,
                    ReleasedOn = g.ReleasedOn.ToString(GameReleaseDateFormat),
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await context.Games
                .AsNoTracking()
                .Where(g => g.Id == id)
                .Select(g => new GameDeleteViewModel()
                {
                    Id = g.Id,
                    Title = g.Title,
                    Publisher = g.Publisher.UserName
                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = await context.Games
                .FindAsync(id);

            if (game == null)
            {
                return BadRequest();
            }

            var gamerGames = await context.GamersGames
                .Where(gg => gg.GameId == id)
                .ToListAsync();

            context.GamersGames.RemoveRange(gamerGames);
            context.Games.Remove(game);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
