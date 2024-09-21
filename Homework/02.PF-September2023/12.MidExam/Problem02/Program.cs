namespace Problem02
{
    internal class Program // Tax Calculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(">>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double totalTax = 0;

            for (int i = 0; i < input.Length; i++)
            {
                string[] currentCar = input[i]
                    .Split();

                string carType = currentCar[0];
                int years = int.Parse(currentCar[1]);
                int kilometers = int.Parse(currentCar[2]);

                double totalCarTax = 0;

                if (carType != "family" && carType != "heavyDuty" && carType != "sports")
                {
                    Console.WriteLine("Invalid car type.");
                    continue;
                }

                if (carType == "family")
                {
                    int initialTax = 50;
                    totalCarTax += initialTax;

                    int distance = 3000;
                    int additionalTax = 12;
                    double taxIncrease = kilometers / distance * additionalTax;

                    int annualDiscount = 5;
                    double taxDecrease = years * annualDiscount;

                    totalCarTax += taxIncrease;
                    totalCarTax -= taxDecrease;

                    Console.WriteLine($"A {carType:f2} car will pay {totalCarTax:f2} euros in taxes.");

                    totalTax += totalCarTax;
                }
                else if (carType == "heavyDuty")
                {
                    int initialTax = 80;
                    totalCarTax += initialTax;

                    int distance = 9000;
                    int additionalTax = 14;
                    double taxIncrease = kilometers / distance * additionalTax;

                    int annualDiscount = 8;
                    double taxDecrease = years * annualDiscount;

                    totalCarTax += taxIncrease;
                    totalCarTax -= taxDecrease;

                    Console.WriteLine($"A {carType:f2} car will pay {totalCarTax:f2} euros in taxes.");

                    totalTax += totalCarTax;
                }
                else if (carType == "sports")
                {
                    int initialTax = 100;
                    totalCarTax += initialTax;

                    int distance = 2000;
                    int additionalTax = 18;
                    double taxIncrease = kilometers / distance * additionalTax;

                    int annualDiscount = 9;
                    double taxDecrease = years * annualDiscount;

                    totalCarTax += taxIncrease;
                    totalCarTax -= taxDecrease;

                    Console.WriteLine($"A {carType:f2} car will pay {totalCarTax:f2} euros in taxes.");

                    totalTax += totalCarTax;
                }
            }

            Console.WriteLine($"The National Revenue Agency will collect {totalTax:f2} euros in taxes.");
        }
    }
}