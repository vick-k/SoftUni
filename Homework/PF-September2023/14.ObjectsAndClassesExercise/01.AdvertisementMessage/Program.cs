namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int messagesCount = int.Parse(Console.ReadLine());

            Ad ad = new Ad();

            ad.Phrases = new[]
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
            };

            ad.Events = new[]
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            ad.Authors = new[]
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            ad.Cities = new[]
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            Random rnd = new Random();

            for (int i = 0; i < messagesCount; i++)
            {
                int randomIndex = rnd.Next(ad.Phrases.Length);
                string phraseAd = ad.Phrases[randomIndex];

                randomIndex = rnd.Next(ad.Events.Length);
                string eventAd = ad.Events[randomIndex];

                randomIndex = rnd.Next(ad.Authors.Length);
                string authorAd = ad.Authors[randomIndex];

                randomIndex = rnd.Next(ad.Cities.Length);
                string cityAd = ad.Cities[randomIndex];

                Console.WriteLine($"{phraseAd} {eventAd} {authorAd} – {cityAd}.");
            }
        }

        public class Ad
        {
            public string[] Phrases { get; set; }
            public string[] Events { get; set; }
            public string[] Authors { get; set; }
            public string[] Cities { get; set; }
        }
    }
}