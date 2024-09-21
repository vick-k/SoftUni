namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new();

            doublyLinkedList.AddFirst(1);
            doublyLinkedList.AddFirst(2);
            doublyLinkedList.AddLast(3);
            doublyLinkedList.AddLast(4);
            doublyLinkedList.AddLast(5);
            doublyLinkedList.RemoveFirst();
            doublyLinkedList.RemoveLast();

            doublyLinkedList.ForEach(n => Console.WriteLine(n));

            int[] array = doublyLinkedList.ToArray();
        }
    }
}
