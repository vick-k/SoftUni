namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new();
            int index = random.Next(0, Count);
            string removedString = this[index];
            RemoveAt(index);

            return removedString;
        }
    }
}
