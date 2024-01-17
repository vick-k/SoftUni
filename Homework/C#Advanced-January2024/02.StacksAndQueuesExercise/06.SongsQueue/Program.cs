namespace _06.SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ");

            Queue<string> playlist = new(songs);

            while (playlist.Count > 0)
            {
                string[] command = Console.ReadLine()
                    .Split();

                if (command[0] == "Play")
                {
                    playlist.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    string song = string.Join(" ", command.Skip(1));

                    if (playlist.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }

                    playlist.Enqueue(song);
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", playlist));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
