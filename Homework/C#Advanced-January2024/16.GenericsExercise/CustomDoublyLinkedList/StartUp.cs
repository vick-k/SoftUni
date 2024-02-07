namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> intLinkedList = new();

            intLinkedList.AddFirst(1);
            intLinkedList.AddFirst(2);
            intLinkedList.AddLast(3);
            intLinkedList.AddLast(4);
            intLinkedList.AddLast(5);
            intLinkedList.RemoveFirst();
            intLinkedList.RemoveLast();

            intLinkedList.ForEach(n => Console.WriteLine(n));

            int[] intArr = intLinkedList.ToArray();

            DoublyLinkedList<string> stringLinkedList = new();

            stringLinkedList.AddFirst("a");
            stringLinkedList.AddFirst("b");
            stringLinkedList.AddLast("c");
            stringLinkedList.AddLast("d");
            stringLinkedList.AddLast("e");
            stringLinkedList.RemoveFirst();
            stringLinkedList.RemoveLast();

            stringLinkedList.ForEach(n => Console.WriteLine(n));

            string[] stringArr = stringLinkedList.ToArray();
        }
    }
}
