namespace _04.ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine()
                .Split()
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());

            string[] newArray = new string[array.Length];

            for (int i = 0; i < rotations; i++)
            {
                newArray[newArray.Length - 1] = array[0];

                int index = 0;
                for (int j = 1; j < array.Length; j++)
                {
                    newArray[index] = array[j];
                    index++;
                }

                array = newArray;
                newArray = new string[array.Length];
            }

            Console.WriteLine(string.Join(" ", array));
        }
    }
}