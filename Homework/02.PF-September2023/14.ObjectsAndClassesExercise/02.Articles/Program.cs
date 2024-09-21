namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleArr = Console.ReadLine()
                .Split(", ");

            string title = articleArr[0];
            string content = articleArr[1];
            string author = articleArr[2];

            Article article = new Article(title, content, author);

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(": ");

                if (command[0] == "Edit")
                {
                    string newContent = command[1];
                    article.Edit(newContent);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    string newAuthor = command[1];
                    article.ChangeAuthor(newAuthor);
                }
                else // "Rename"
                {
                    string newTitle = command[1];
                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public string Edit(string newContent)
            {
                return Content = newContent;
            }

            public string ChangeAuthor(string newAuthor)
            {
                return Author = newAuthor;
            }

            public string Rename(string newTitle)
            {
                return Title = newTitle;
            }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}