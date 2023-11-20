using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder input = new StringBuilder(Console.ReadLine());

            int explosionRemain = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    int explosionStrength = int.Parse(input[i + 1].ToString()) + explosionRemain;

                    for (int j = 1; j <= explosionStrength; j++)
                    {
                        if (i + 1 < input.Length && input[i + 1] != '>')
                        {
                            input.Remove(i + 1, 1);
                            explosionRemain = explosionStrength - j;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(input);
        }
    }
}