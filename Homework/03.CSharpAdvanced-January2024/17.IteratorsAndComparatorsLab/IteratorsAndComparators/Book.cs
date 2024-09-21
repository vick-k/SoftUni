namespace IteratorsAndComparators
{
    // 4. BookComparer (the solutions of the other problems are at the bottom)
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList(); ;
        }

        public string Title { get; private set; }
        public int Year { get; private set; }
        public List<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }

            return result;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }

    // Problems:
    // 1. Library
    //public class Book
    //{
    //    public Book(string title, int year, params string[] authors)
    //    {
    //        Title = title;
    //        Year = year;
    //        Authors = authors;
    //    }

    //    public string Title { get; set; }
    //    public int Year { get; set; }
    //    public IReadOnlyList<string> Authors { get; set; }
    //}

    // 2. Library Iterator
    //public class Book
    //{
    //    public Book(string title, int year, params string[] authors)
    //    {
    //        Title = title;
    //        Year = year;
    //        Authors = authors.ToList(); ;
    //    }

    //    public string Title { get; private set; }
    //    public int Year { get; private set; }
    //    public List<string> Authors { get; private set; }
    //}

    // 3. Comparable Book
    //public class Book : IComparable<Book>
    //{
    //    public Book(string title, int year, params string[] authors)
    //    {
    //        Title = title;
    //        Year = year;
    //        Authors = authors.ToList(); ;
    //    }

    //    public string Title { get; private set; }
    //    public int Year { get; private set; }
    //    public List<string> Authors { get; private set; }

    //    public int CompareTo(Book other)
    //    {
    //        int result = Year.CompareTo(other.Year);

    //        if (result == 0)
    //        {
    //            result = Title.CompareTo(other.Title);
    //        }

    //        return result;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Title} - {Year}";
    //    }
    //}
}
