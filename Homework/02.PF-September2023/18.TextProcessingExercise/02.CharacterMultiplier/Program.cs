namespace _02.CharacterMultiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            int result = Sum(input[0], input[1]);

            Console.WriteLine(result);
        }

        static int Sum(string first, string second)
        {
            string shorterString = first;
            string longerString = second;

            if (first.Length > second.Length)
            {
                shorterString = second;
                longerString = first;
            }

            int sum = 0;

            for (int i = 0; i < shorterString.Length; i++)
            {
                sum += first[i] * second[i];
            }

            if (shorterString.Length != longerString.Length)
            {
                for (int i = shorterString.Length; i < longerString.Length; i++)
                {
                    sum += longerString[i];
                }
            }

            return sum;
        }
    }
}