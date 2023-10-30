namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int songsCount = int.Parse(Console.ReadLine());

            List<Song> playlist = new List<Song>();

            for (int i = 0; i < songsCount; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("_");

                string typeList = input[0];
                string songName = input[1];
                string songTime = input[2];

                Song song = new Song();

                song.TypeList = typeList;
                song.SongName = songName;
                song.SongTime = songTime;

                playlist.Add(song);
            }

            string filter = Console.ReadLine();

            if (filter != "all")
            {
                foreach (Song song in playlist)
                {
                    if (filter == song.TypeList)
                    {
                        Console.WriteLine(song.SongName);
                    }
                }
            }
            else
            {
                foreach (Song song in playlist)
                {
                    Console.WriteLine(song.SongName);
                }
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string SongName { get; set; }
        public string SongTime { get; set; }
    }
}