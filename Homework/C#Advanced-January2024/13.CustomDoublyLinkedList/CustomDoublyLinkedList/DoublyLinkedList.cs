namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private ListNode head;
        private ListNode tail;

        private class ListNode
        {
            public int Value { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public ListNode(int value)
            {
                Value = value;
            }
        }

        public int Count { get; set; }

        public void AddFirst(int element)
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

        public void AddLast(int element)
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

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int firstElement = head.Value;
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

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int lastElement = tail.Value;
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

        public void ForEach(Action<int> action)
        {
            ListNode currentNode = head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];

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
