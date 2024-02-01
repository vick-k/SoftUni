namespace _05.DateModifier
{
    public class DateModifier
    {
        public static int CalculateDaysDifference(string startDate, string endDate)
        {
            DateTime start = DateTime.Parse(startDate);
            DateTime end = DateTime.Parse(endDate);

            TimeSpan difference = start - end;

            return Math.Abs(difference.Days);
        }
    }
}
