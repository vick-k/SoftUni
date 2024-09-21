namespace CustomQueue
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomQueue customQueue = new CustomQueue();

            customQueue.Enqueue(11);
            customQueue.Enqueue(22);
            customQueue.Enqueue(33);
            customQueue.Enqueue(44);
            customQueue.Enqueue(55);
            customQueue.Enqueue(66);
            customQueue.Enqueue(77);
            customQueue.Enqueue(88);
            customQueue.Enqueue(99);

            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();
            customQueue.Dequeue();

            customQueue.Peek();

            //customQueue.Clear();

            customQueue.ForEach(i => Console.WriteLine(i));
        }
    }
}
