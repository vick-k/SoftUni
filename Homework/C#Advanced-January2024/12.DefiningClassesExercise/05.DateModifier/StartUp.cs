namespace _05.DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            int difference = DateModifier.CalculateDaysDifference(startDate, endDate);
            Console.WriteLine(difference);
        }
    }
}
