namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainersList = new();

            string input;
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] arguments = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = arguments[0];
                string pokemonName = arguments[1];
                string pokemonElement = arguments[2];
                int pokemonHealth = int.Parse(arguments[3]);

                Pokemon pokemon = new(pokemonName, pokemonElement, pokemonHealth);

                if (!trainersList.Exists(t => t.Name == trainerName))
                {
                    Trainer trainer = new(trainerName, 0, new());
                    trainersList.Add(trainer);
                }

                Trainer currentTrainer = trainersList.Find(t => t.Name == trainerName);
                currentTrainer.PokemonsList.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                PlayPokemon(trainersList, input);
            }

            trainersList = trainersList.OrderByDescending(t => t.BadgesCount).ToList();

            foreach (Trainer trainer in trainersList)
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.PokemonsList.Count}");
            }
        }

        private static void PlayPokemon(List<Trainer> trainersList, string input)
        {
            foreach (Trainer trainer in trainersList)
            {
                if (trainer.PokemonsList.Exists(p => p.Element == input))
                {
                    trainer.BadgesCount++;
                }
                else
                {
                    for (int i = 0; i < trainer.PokemonsList.Count; i++)
                    {
                        trainer.PokemonsList[i].Health -= 10;

                        if (trainer.PokemonsList[i].Health <= 0)
                        {
                            trainer.PokemonsList.RemoveAt(i);
                        }
                    }
                }
            }
        }
    }
}
