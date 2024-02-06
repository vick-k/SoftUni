namespace CustomList
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();

            customList.Add(11);
            customList.Add(22);
            customList.Add(33);
            customList.Add(44);

            //customList.RemoveAt(3);
            //customList.RemoveAt(1);
            //customList.RemoveAt(1);

            customList.InsertAt(2, 333);
            customList.Add(44);

            //Console.WriteLine(customList.Contains(55));

            customList.Swap(0, 2);

            Console.WriteLine(customList[1]);
            Console.WriteLine(customList.Count);
        }
    }
}
