namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int badgesCount, List<Pokemon> pokemonsList)
        {
            Name = name;
            BadgesCount = badgesCount;
            PokemonsList = pokemonsList = new();
        }

        public string Name { get; set; }

        public int BadgesCount { get; set; }

        public List<Pokemon> PokemonsList { get; set; }
    }
}
