namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries);

            List<string> result = new List<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                string[] fixedArray = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                result.AddRange(fixedArray);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}