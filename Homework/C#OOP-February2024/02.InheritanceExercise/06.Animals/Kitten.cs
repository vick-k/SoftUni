using System;

namespace Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, null)
        {

        }

        public override string Gender { get => "Female"; }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
