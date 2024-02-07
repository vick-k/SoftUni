namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode head;
        private ListNode tail;

        private class ListNode
        {
            public T Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode(T value)
            {
                Value = value;
            }
        }

        public int Count { get; set; }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                ListNode newHead = new(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode(element);
            }
            else
            {
                ListNode newTail = new(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T firstElement = head.Value;
            head = head.NextNode;

            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }

            Count--;
            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T lastElement = tail.Value;
            tail = tail.PreviousNode;

            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }

            Count--;
            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                array[i] = head.Value;
                head = head.NextNode;
            }

            return array;

            // Variant 2:
            //int[] array = new int[Count];
            //int counter = 0;
            //ListNode currentNode = head;
            //while (currentNode != null)
            //{
            //    array[counter] = currentNode.Value;
            //    currentNode = currentNode.NextNode;
            //    counter++;
            //}

            //return array;
        }
    }
}
