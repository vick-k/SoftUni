namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, uint> resourceMap = new Dictionary<string, uint>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                uint quantity = uint.Parse(Console.ReadLine());

                if (!resourceMap.ContainsKey(resource))
                {
                    resourceMap.Add(resource, quantity);
                }
                else
                {
                    resourceMap[resource] += quantity;
                }
            }

            foreach (var kvp in resourceMap)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}