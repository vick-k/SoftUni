using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.Serialization;

using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Controllers
{
    [Authorize]
    public class ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            string userId = userManager.GetUserId(User);

            List<Product> products = await context.Products
                .AsNoTracking()
                .Where(p => p.IsDeleted == false)
                .Include(p => p.Seller)
                .ToListAsync();

            var viewModels = products
                .Select(p => new ProductAllViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Seller = p.Seller.UserName,
                    IsSeller = userId == p.SellerId ? true : false,
                    HasBought = context.ProductsClients
                        .Where(pc => pc.ClientId == userId && pc.ProductId == p.Id)
                        .Any() ? true : false
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

            var viewModel = new ProductAddViewModel()
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductAddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            string userId = userManager.GetUserId(User)!;

            var dateString = viewModel.AddedOn;

            if (!DateTime.TryParseExact(dateString, ProductDateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                ModelState.AddModelError("AddedOn", $"Invalid date format. Please use: {ProductDateTimeFormat}");

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

            var product = new Product()
            {
                ProductName = viewModel.ProductName,
                Description = viewModel.Description,
                Price = viewModel.Price,
                ImageUrl = viewModel.ImageUrl,
                SellerId = userId,
                AddedOn = parseDate,
                CategoryId = viewModel.CategoryId
            };

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            string userId = userManager.GetUserId(User)!;

            var viewModel = await context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDetailsViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    ProductName = p.ProductName,
                    Price = p.Price,
                    Description = p.Description,
                    CategoryName = p.Category.Name,
                    AddedOn = p.AddedOn.ToString(ProductDateTimeFormat, CultureInfo.InvariantCulture),
                    Seller = p.Seller.UserName!,
                    HasBought = context.ProductsClients
                        .Where(pc => pc.ClientId == userId && pc.ProductId == p.Id)
                        .Any() ? true : false
                })
                .FirstOrDefaultAsync();

            if (viewModel == null)
            {
                return BadRequest();
            }

            return View(viewModel);
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

            var product = await context.Products
                .FindAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            var viewModel = new ProductAddViewModel()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                AddedOn = product.AddedOn.ToString(ProductDateTimeFormat, CultureInfo.InvariantCulture),
                SellerId = product.SellerId,
                CategoryId = product.CategoryId,
                Categories = categories
            };

            if (viewModel.SellerId != userId)
            {
                return Unauthorized();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ProductAddViewModel viewModel)
        {
            var product = await context.Products
                .FindAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            string userId = userManager.GetUserId(User)!;

            if (product.SellerId != userId)
            {
                return Unauthorized();
            }

            var dateString = viewModel.AddedOn;

            if (!DateTime.TryParseExact(dateString, ProductDateTimeFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime parseDate))
            {
                ModelState.AddModelError("DateAndTime", $"Invalid date format. Please use: {ProductDateTimeFormat}");

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

            product.ProductName = viewModel.ProductName;
            product.Description = viewModel.Description;
            product.Price = viewModel.Price;
            product.ImageUrl = viewModel.ImageUrl;
            product.SellerId = viewModel.SellerId;
            product.AddedOn = parseDate;
            product.CategoryId = viewModel.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = userManager.GetUserId(User)!;

            var productsClient = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ClientId == userId && pc.ProductId == id);

            if (productsClient == null)
            {
                productsClient = new ProductClient()
                {
                    ClientId = userId,
                    ProductId = id,
                };

                await context.ProductsClients.AddAsync(productsClient);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var userId = userManager.GetUserId(User);

            var products = await context.ProductsClients
                .AsNoTracking()
                .Where(pc => pc.ClientId == userId)
                .Include(pc => pc.Product)
                .Select(pc => new ProductCartViewModel()
                {
                    Id = pc.ProductId,
                    ImageUrl = pc.Product.ImageUrl,
                    ProductName = pc.Product.ProductName,
                    Price = pc.Product.Price
                })
                .ToListAsync();

            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            string userId = userManager.GetUserId(User)!;

            var productClient = await context.ProductsClients
                .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == userId);

            if (productClient != null)
            {
                context.ProductsClients.Remove(productClient);
                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = await context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => new ProductDeleteViewModel()
                {
                    Id = p.Id,
                    ProductName = p.ProductName,
                    Seller = p.Seller.UserName!,
                    SellerId = p.SellerId
                })
                .FirstOrDefaultAsync();

            if (viewModel == null)
            {
                return BadRequest();
            }

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, ProductDeleteViewModel viewModel)
        {
            var product = await context.Products
                .FindAsync(id);

            if (product == null)
            {
                return BadRequest();
            }

            //var clientProducts = await context.ProductsClients
            //    .Where(pc => pc.ProductId == id)
            //    .ToListAsync();

            //context.ProductsClients.RemoveRange(clientProducts);
            product.IsDeleted = true;
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
