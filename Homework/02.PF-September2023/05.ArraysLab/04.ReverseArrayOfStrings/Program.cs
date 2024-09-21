namespace _04.ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            string[] reversed = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = input[input.Length - (1 + i)];
            }

            Console.Write(string.Join(" ", reversed));
        }
    }
}