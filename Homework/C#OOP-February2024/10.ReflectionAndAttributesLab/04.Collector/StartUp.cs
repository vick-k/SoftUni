﻿namespace Stealer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new();
            string result = spy.CollectGettersAndSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
