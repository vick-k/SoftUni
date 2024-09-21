using System.Text;

namespace _08.Threeuple
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

                    StringBuilder sb = new();

                    for (int j = 3; j < input.Length; j++)
                    {
                        sb.Append($"{input[j]} ");
                    }

                    string town = sb.ToString().TrimEnd();

                    Threeuple<string, string, string> threeuple = new(name, address, town);
                    Console.WriteLine(threeuple);
                }
                else if (i == 1)
                {
                    string name = input[0];
                    int litersOfBeer = int.Parse(input[1]);
                    bool isDrunk = input[2] == "drunk";

                    Threeuple<string, int, bool> threeuple = new(name, litersOfBeer, isDrunk);
                    Console.WriteLine(threeuple);
                }
                else
                {
                    string name = input[0];
                    double accountBalance = double.Parse(input[1]);
                    string bankName = input[2];

                    Threeuple<string, double, string> threeuple = new(name, accountBalance, bankName);
                    Console.WriteLine(threeuple);
                }
            }
        }
    }
}
