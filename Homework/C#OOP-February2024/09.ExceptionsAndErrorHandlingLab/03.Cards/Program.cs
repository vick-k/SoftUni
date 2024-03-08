namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new();

            string[] deck = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string cardInfo in deck)
            {
                string[] arguments = cardInfo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = arguments[0];
                string suit = arguments[1];

                try
                {
                    Card card = CreateCard(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        private static Card CreateCard(string face, string suit)
        {
            return new Card(face, suit);
        }
    }

    class Card
    {
        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get { return face; }
            set
            {
                if (value != "2" && value != "3" && value != "4" && value != "5" && value != "6" && value != "7" && value != "8" && value != "9" && value != "10" && value != "J" && value != "Q" && value != "K" && value != "A")
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }
        public string Suit
        {
            get { return suit; }
            set
            {
                if (value != "S" && value != "H" && value != "D" && value != "C")
                {
                    throw new ArgumentException("Invalid card!");
                }

                suit = value;
            }
        }

        public override string ToString()
        {
            if (Suit == "S")
            {
                return $"[{Face}\u2660]";
            }
            else if (Suit == "H")
            {
                return $"[{Face}\u2665]";
            }
            else if (Suit == "D")
            {
                return $"[{Face}\u2666]";
            }
            else
            {
                return $"[{Face}\u2663]";
            }
        }
    }
}
