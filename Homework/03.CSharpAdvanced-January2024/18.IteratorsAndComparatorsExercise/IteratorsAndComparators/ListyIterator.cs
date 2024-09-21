using System.Collections;

namespace IteratorsAndComparators
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index = 0;

        public ListyIterator(List<T> list)
        {
            this.list = list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool HasNext()
        {
            return index < list.Count - 1;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            
            return false;
        }

        public void Print()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
                return;
            }

            Console.WriteLine(list[index]);
        }
    }

    // Problems:

    // 1. ListyIterator
    //public class ListyIterator<T>
    //{
    //    private List<T> list;
    //    private int index = 0;

    //    public ListyIterator(List<T> list)
    //    {
    //        this.list = list;
    //    }

    //    public bool HasNext()
    //    {
    //        return index < list.Count - 1;
    //    }

    //    public bool Move()
    //    {
    //        if (HasNext())
    //        {
    //            index++;
    //            return true;
    //        }

    //        return false;
    //    }

    //    public void Print()
    //    {
    //        if (list.Count == 0)
    //        {
    //            Console.WriteLine("Invalid Operation!");
    //            return;
    //        }

    //        Console.WriteLine(list[index]);
    //    }
    //}

    // 2. Collection
    //public class ListyIterator<T> : IEnumerable<T>
    //{
    //    private List<T> list;
    //    private int index = 0;

    //    public ListyIterator(List<T> list)
    //    {
    //        this.list = list;
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            yield return list[i];
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    public bool HasNext()
    //    {
    //        return index < list.Count - 1;
    //    }

    //    public bool Move()
    //    {
    //        if (HasNext())
    //        {
    //            index++;
    //            return true;
    //        }

    //        return false;
    //    }

    //    public void Print()
    //    {
    //        if (list.Count == 0)
    //        {
    //            Console.WriteLine("Invalid Operation!");
    //            return;
    //        }

    //        Console.WriteLine(list[index]);
    //    }
    //}
}
