namespace _03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < articlesCount; i++)
            {
                string[] articleArr = Console.ReadLine()
                    .Split(", ");

                string title = articleArr[0];
                string content = articleArr[1];
                string author = articleArr[2];

                Article article = new Article(title, content, author);

                Console.WriteLine(article);
            }
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

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }
    }
}