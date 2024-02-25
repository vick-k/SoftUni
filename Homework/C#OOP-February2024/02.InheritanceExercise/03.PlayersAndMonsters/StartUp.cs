using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Elf elf = new("user1", 1);
            MuseElf museElf = new("user2", 2);
            Wizard wizard = new("user3", 3);
            DarkWizard darkWizard = new("user4", 4);
            SoulMaster soulMaster = new("user5", 5);
            Knight knight = new("user6", 6);
            DarkKnight darkKnight = new("user7", 7);
            BladeKnight bladeKnight = new("user8", 8);

            Console.WriteLine(elf);
            Console.WriteLine(museElf);
            Console.WriteLine(wizard);
            Console.WriteLine(darkWizard);
            Console.WriteLine(soulMaster);
            Console.WriteLine(knight);
            Console.WriteLine(darkKnight);
            Console.WriteLine(bladeKnight);

        }
    }
}