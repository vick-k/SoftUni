namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                if (i == 0)
                {
                    string name = $"{input[0]} {input[1]}";
                    string address = input[2];

                    CustomTuple<string, string> customTuple = new(name, address);
                    Console.WriteLine(customTuple);
                }
                else if (i == 1)
                {
                    string name = input[0];
                    int litersOfBeer = int.Parse(input[1]);

                    CustomTuple<string, int> customTuple = new(name, litersOfBeer);
                    Console.WriteLine(customTuple);
                }
                else
                {
                    int firstNum = int.Parse(input[0]);
                    double secondNum = double.Parse(input[1]);

                    CustomTuple<int, double> customTuple = new(firstNum, secondNum);
                    Console.WriteLine(customTuple);
                }
            }
        }
    }
}
