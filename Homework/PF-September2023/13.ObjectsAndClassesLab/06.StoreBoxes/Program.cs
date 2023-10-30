namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxesList = new List<Box>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemData = input.Split();

                string serialNumber = itemData[0];
                string itemName = itemData[1];
                int itemQuantity = int.Parse(itemData[2]);
                double itemPrice = double.Parse(itemData[3]);

                Item item = new Item();

                item.Name = itemName;
                item.Price = itemPrice;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.Item = item;
                box.ItemQuantity = itemQuantity;
                box.BoxPrice = itemPrice * itemQuantity;

                boxesList.Add(box);
            }

            boxesList = boxesList.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in boxesList)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.BoxPrice:f2}");
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        public class Box
        {
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double BoxPrice { get; set; }
        }
    }
}