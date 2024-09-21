namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void AddRange(string[] strings)
        {
            foreach(string s in strings)
            {
                Push(s);
            }
        }
    }
}
