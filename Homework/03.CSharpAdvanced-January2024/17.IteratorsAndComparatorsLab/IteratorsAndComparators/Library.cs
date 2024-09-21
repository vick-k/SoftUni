using System.Collections;

namespace IteratorsAndComparators
{
    // 4. BookComparer (the solutions of the other problems are at the bottom)
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books.OrderBy(book => book.Title).ToList());
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }
            public void Reset()
            {
                currentIndex = -1;
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;
        }
    }

    // Problems:
    // 1. Library
    //public class Library
    //{
    //    private List<Book> books;

    //    public Library(params Book[] books)
    //    {
    //        this.books = new List<Book>(books);
    //    }
    //}

    // 2. Library Iterator
    //public class Library : IEnumerable<Book>
    //{
    //    private List<Book> books;

    //    public Library(params Book[] books)
    //    {
    //        this.books = new List<Book>(books);
    //    }

    //    public IEnumerator<Book> GetEnumerator()
    //    {
    //        return new LibraryIterator(books);
    //    }

    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //    private class LibraryIterator : IEnumerator<Book>
    //    {
    //        private readonly List<Book> books;
    //        private int currentIndex;

    //        public LibraryIterator(IEnumerable<Book> books)
    //        {
    //            Reset();
    //            this.books = new List<Book>(books);
    //        }

    //        public void Dispose() { }

    //        public bool MoveNext()
    //        {
    //            return ++currentIndex < books.Count;
    //        }
    //        public void Reset()
    //        {
    //            currentIndex = -1;
    //        }

    //        public Book Current => books[currentIndex];

    //        object IEnumerator.Current => Current;
    //    }
    //}

    // 3. Comparable Book
    //public class Library : IEnumerable<Book>
    //{
    //    private List<Book> books;

    //    public Library(params Book[] books)
    //    {
    //        this.books = new List<Book>(books);
    //    }

    //    public IEnumerator<Book> GetEnumerator()
    //    {
    //        return new LibraryIterator(books.OrderBy(book => book).ToList());
    //    }

    //    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //    private class LibraryIterator : IEnumerator<Book>
    //    {
    //        private readonly List<Book> books;
    //        private int currentIndex;

    //        public LibraryIterator(IEnumerable<Book> books)
    //        {
    //            Reset();
    //            this.books = new List<Book>(books);
    //        }

    //        public void Dispose() { }

    //        public bool MoveNext()
    //        {
    //            return ++currentIndex < books.Count;
    //        }
    //        public void Reset()
    //        {
    //            currentIndex = -1;
    //        }

    //        public Book Current => books[currentIndex];

    //        object IEnumerator.Current => Current;
    //    }
    //}
}
