namespace IteratorsAndComparators
{
    // 6. Equality Logic
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);

            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;

            if (other == null)
            {
                return false;
            }

            return Name == other.Name && Age == other.Age;
        }
    }

    // 5. Comparing Objects
    //public class Person : IComparable<Person>
    //{
    //    public Person(string name, int age, string town)
    //    {
    //        Name = name;
    //        Age = age;
    //        Town = town;
    //    }

    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public string Town { get; set; }

    //    public int CompareTo(Person other)
    //    {
    //        int result = Name.CompareTo(other.Name);

    //        if (result != 0)
    //        {
    //            return result;
    //        }

    //        result = Age.CompareTo(other.Age);

    //        if (result != 0)
    //        {
    //            return result;
    //        }

    //        return Town.CompareTo(other.Town);
    //    }
    //}
}
