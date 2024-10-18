using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using static SeminarHub.Common.ValidationConstants;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public SeminarController(SeminarHubDbContext _context, UserManager<IdentityUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var seminars = await context.Seminars
                .AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.Organizer)
                .ToListAsync();

            var viewModels = seminars
                .Select(s => new SeminarAllViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Organizer = s.Organizer.UserName
                });

            return View(viewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            var viewModel = new SeminarAddViewModel()
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string userId = userManager.GetUserId(User);

            var dateString = viewModel.DateAndTime;

            if (!DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                ModelState.AddModelError("DateAndTime", $"Invalid date format. Please use: {DateTimeFormat}");

                var categories = await context.Categories
                    .AsNoTracking()
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToListAsync();

                viewModel.Categories = categories;

                return View(viewModel);
            }

            var seminar = new Seminar()
            {
                Topic = viewModel.Topic,
                Lecturer = viewModel.Lecturer,
                Details = viewModel.Details,
                OrganizerId = userId,
                DateAndTime = parseDate,
                Duration = viewModel.Duration,
                CategoryId = viewModel.CategoryId
            };

            await context.Seminars.AddAsync(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = userManager.GetUserId(User);

            var seminars = await context.SeminarsParticipants
                .AsNoTracking()
                .Where(sp => sp.ParticipantId == userId)
                .Include(sp => sp.Seminar)
                .Select(sp => new SeminarJoinedViewModel()
                {
                    Id = sp.SeminarId,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Organizer = sp.Seminar.Organizer.UserName
                })
                .ToListAsync();

            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = userManager.GetUserId(User);

            var categories = await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

            var seminar = await context.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            var viewModel = new SeminarAddViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                Duration = seminar.Duration,
                OrganizerId = seminar.OrganizerId,
                CategoryId = seminar.CategoryId,
                Categories = categories
            };

            if (viewModel.OrganizerId != userId)
            {
                return Unauthorized();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, SeminarAddViewModel viewModel)
        {
            var seminar = await context.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = userManager.GetUserId(User);

            if (seminar.OrganizerId != userId)
            {
                return Unauthorized();
            }

            var dateString = viewModel.DateAndTime;

            if (!DateTime.TryParseExact(dateString, DateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                ModelState.AddModelError("DateAndTime", $"Invalid date format. Please use: {DateTimeFormat}");

                var categories = await context.Categories
                    .AsNoTracking()
                    .Select(c => new CategoryViewModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                    })
                    .ToListAsync();

                viewModel.Categories = categories;

                return View(viewModel);
            }

            seminar.Topic = viewModel.Topic;
            seminar.Lecturer = viewModel.Lecturer;
            seminar.Details = viewModel.Details;
            seminar.DateAndTime = parseDate;
            seminar.Duration = viewModel.Duration;
            seminar.CategoryId = viewModel.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            string userId = userManager.GetUserId(User);

            var seminarParticipant = await context.SeminarsParticipants
                .FirstOrDefaultAsync(sp => sp.SeminarId == id && sp.ParticipantId == userId);

            if (seminarParticipant == null)
            {
                seminarParticipant = new SeminarParticipant()
                {
                    SeminarId = id,
                    ParticipantId = userId
                };

                await context.SeminarsParticipants.AddAsync(seminarParticipant);
                await context.SaveChangesAsync();
            }
            else
            {
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            string userId = userManager.GetUserId(User);

            var seminarParticipant = await context.SeminarsParticipants
                .FirstOrDefaultAsync(sp => sp.SeminarId == id && sp.ParticipantId == userId);

            if (seminarParticipant != null)
            {
                context.SeminarsParticipants.Remove(seminarParticipant);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var viewModel = await context.Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDetailsViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime.ToString(DateTimeFormat, CultureInfo.InvariantCulture),
                    Duration = s.Duration,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    Details = s.Details,
                    Organizer = s.Organizer.UserName
                })
                .FirstOrDefaultAsync();

            if (viewModel == null)
            {
                return BadRequest();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string userId = userManager.GetUserId(User);
            var seminar = await context.Seminars.FindAsync(id);

            if (seminar == null || userId != seminar.OrganizerId)
            {
                return Unauthorized();
            }

            var viewModel = await context.Seminars
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(s => new SeminarDeleteViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    DateAndTime = s.DateAndTime
                })
                .FirstOrDefaultAsync();

            if (viewModel == null)
            {
                return BadRequest();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await context.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            var seminarParticipants = await context.SeminarsParticipants
                .Where(sp => sp.SeminarId == id)
                .ToListAsync();

            context.SeminarsParticipants.RemoveRange(seminarParticipants);
            context.Seminars.Remove(seminar);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }
    }
}
