namespace IteratorsAndComparators
{
    // 7. Custom Comparator
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            CustomComparator comparer = new();
            Array.Sort(input, comparer);
            Console.WriteLine(string.Join(" ", input));
        }

        //Problems:

        // 1. ListyIterator
        //static void Main(string[] args)
        //{
        //    var input = Console.ReadLine()
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //    ListyIterator<string> listy = new(input.Skip(1).ToList());

        //    string command;
        //    while ((command = Console.ReadLine()) != "END")
        //    {
        //        if (command == "Print")
        //        {
        //            listy.Print();
        //        }
        //        else if (command == "HasNext")
        //        {
        //            Console.WriteLine(listy.HasNext());
        //        }
        //        else if (command == "Move")
        //        {
        //            Console.WriteLine(listy.Move());
        //        }
        //    }
        //}

        // 2. Collection
        //static void Main(string[] args)
        //{
        //    var input = Console.ReadLine()
        //        .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        //    ListyIterator<string> listy = new(input.Skip(1).ToList());

        //    string command;
        //    while ((command = Console.ReadLine()) != "END")
        //    {
        //        if (command == "Print")
        //        {
        //            listy.Print();
        //        }
        //        else if (command == "HasNext")
        //        {
        //            Console.WriteLine(listy.HasNext());
        //        }
        //        else if (command == "Move")
        //        {
        //            Console.WriteLine(listy.Move());
        //        }
        //        else if (command == "PrintAll")
        //        {
        //            foreach (string item in listy)
        //            {
        //                Console.Write($"{item} ");
        //            }

        //            Console.WriteLine();
        //        }
        //    }
        //}

        // 3. Stack
        //static void Main(string[] args)
        //{
        //    CustomStack<string> stack = new();

        //    string command;
        //    while ((command = Console.ReadLine()) != "END")
        //    {
        //        if (command.StartsWith("Push"))
        //        {
        //            string[] elements = command
        //                .Substring(5) // removes "Push" from the command
        //                .Split(", ")
        //                .ToArray();

        //            foreach (string element in elements)
        //            {
        //                stack.Push(element);
        //            }
        //        }
        //        else if (command == "Pop")
        //        {
        //            stack.Pop();
        //        }
        //    }

        //    for (int i = 0; i < 2; i++)
        //    {
        //        foreach (var element in stack)
        //        {
        //            Console.WriteLine(element);
        //        }
        //    }
        //}

        // 4. Froggy
        //static void Main(string[] args)
        //{
        //    int[] stones = Console.ReadLine()
        //        .Split(", ")
        //        .Select(int.Parse)
        //        .ToArray();

        //    Lake lake = new();

        //    for (int i = 0; i < stones.Length; i++)
        //    {
        //        if (i % 2 == 0)
        //        {
        //            lake.EvenStones.Add(stones[i]);
        //        }
        //        else
        //        {
        //            lake.OddStones.Add(stones[i]);
        //        }
        //    }

        //    Console.WriteLine(string.Join(", ", lake));
        //}

        // 5. Comparing Objects
        //static void Main(string[] args)
        //{
        //    List<Person> people = new();

        //    string input;
        //    while ((input = Console.ReadLine()) != "END")
        //    {
        //        string[] arguments = input.Split();
        //        string name = arguments[0];
        //        int age = int.Parse(arguments[1]);
        //        string town = arguments[2];

        //        Person person = new(name, age, town);
        //        people.Add(person);
        //    }

        //    int referenceIndex = int.Parse(Console.ReadLine());
        //    Person referencePerson = people[referenceIndex - 1];

        //    int equalCount = 0;
        //    int differentCount = 0;

        //    foreach (Person person in people)
        //    {
        //        if (person.CompareTo(referencePerson) == 0)
        //        {
        //            equalCount++;
        //        }
        //        else
        //        {
        //            differentCount++;
        //        }
        //    }

        //    if (equalCount == 1)
        //    {
        //        Console.WriteLine("No matches");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{equalCount} {differentCount} {people.Count}");
        //    }
        //}

        // 6. Equality Logic
        //static void Main(string[] args)
        //{
        //    SortedSet<Person> sortedSet = new();
        //    HashSet<Person> hashSet = new();

        //    int peopleCount = int.Parse(Console.ReadLine());

        //    for (int i = 0; i < peopleCount; i++)
        //    {
        //        string[] arguments = Console.ReadLine().Split();
        //        string name = arguments[0];
        //        int age = int.Parse(arguments[1]);

        //        Person person = new(name, age);
        //        sortedSet.Add(person);
        //        hashSet.Add(person);
        //    }

        //    Console.WriteLine(sortedSet.Count);
        //    Console.WriteLine(hashSet.Count);
        //}
    }

    // 7. Custom Comparator
    public class CustomComparator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }

            if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }

            return x.CompareTo(y);
        }
    }
}
