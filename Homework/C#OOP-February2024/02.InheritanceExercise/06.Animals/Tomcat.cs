using System;

namespace Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, null)
        {

        }

        public override string Gender { get => "Male"; }

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
