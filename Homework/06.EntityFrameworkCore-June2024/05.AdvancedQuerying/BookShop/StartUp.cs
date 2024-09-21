namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            // DbInitializer.ResetDatabase(db);

            // 02. Age Restriction
            // Console.WriteLine(GetBooksByAgeRestriction(db, Console.ReadLine()));

            // 03. Golden Books
            // Console.WriteLine(GetGoldenBooks(db));

            // 04. Books by Price
            // Console.WriteLine(GetBooksByPrice(db));

            // 05. Not Released In
            //try
            //{
            //    Console.WriteLine(GetBooksNotReleasedIn(db, int.Parse(Console.ReadLine())));
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("Incorrect format for year!");
            //    return;
            //}

            // 06. Book Titles by Category
            // Console.WriteLine(GetBooksByCategory(db, Console.ReadLine()));

            // 07. Released Before Date
            // Console.WriteLine(GetBooksReleasedBefore(db, Console.ReadLine()));

            // 08. Author Search
            // Console.WriteLine(GetAuthorNamesEndingIn(db, Console.ReadLine()));

            // 09. Book Search
            // Console.WriteLine(GetBookTitlesContaining(db, Console.ReadLine()));

            // 10. Book Search by Author
            // Console.WriteLine(GetBooksByAuthor(db, Console.ReadLine()));

            // 11. Count Books
            //try
            //{
            //    Console.WriteLine(CountBooks(db, int.Parse(Console.ReadLine())));
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("LengthCheck should be an integer number!");
            //    return;
            //}

            // 12. Total Book Copies
            // Console.WriteLine(CountCopiesByAuthor(db));

            // 13. Profit by Category
            // Console.WriteLine(GetTotalProfitByCategory(db));

            // 14. Most Recent Books
            // Console.WriteLine(GetMostRecentBooks(db));

            // 15. Increase Prices
            // IncreasePrices(db);

            // 16. Remove Books
            // Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var booksInfo = context.Books
                .AsEnumerable()
                .Where(b => b.AgeRestriction.ToString().ToLower() == command.ToLower())
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var booksInfo = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksInfo = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksInfo = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine(book.Title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                .ToLower()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var booksInfo = context.BooksCategories
                .Where(b => categories.Contains(b.Category.Name.ToLower()))
                .Select(b => b.Book.Title)
                .OrderBy(b => b)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime releaseDate = DateTime.ParseExact(date, "dd-MM-yyyy", null);

            var booksInfo = context.Books
                .Where(b => b.ReleaseDate < releaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .OrderByDescending(b => b.ReleaseDate)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorsInfo = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName
                })
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorsInfo)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booksInfo = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksInfo = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    AuthorFirstName = b.Author.FirstName,
                    AuthorLastName = b.Author.LastName,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksInfo)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} {book.AuthorLastName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsInfo = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    TotalBookCopies = a.Books.Select(b => b.Copies).Sum()
                })
                .OrderByDescending(b => b.TotalBookCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var author in authorsInfo)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoryInfo = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Price * b.Book.Copies)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoryInfo)
            {
                sb.AppendLine($"{category.Name} ${category.TotalProfit:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryInfo = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksInfo = c.CategoryBooks
                        .Select(b => new
                        {
                            b.Book.Title,
                            b.Book.ReleaseDate,
                        })
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var c in categoryInfo)
            {
                sb.AppendLine($"--{c.CategoryName}");

                foreach (var b in c.BooksInfo)
                {
                    sb.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count;
        }
    }
}
