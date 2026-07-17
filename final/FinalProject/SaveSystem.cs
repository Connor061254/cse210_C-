public class SaveSystem
{
    public void SaveInventory(Inventory inventory, string filename, Player player)
    {
         try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(player._gold);

                writer.WriteLine(inventory.currentInventory.Count);

                foreach(Item item in inventory.currentInventory)
                {
                    writer.WriteLine(item._itemName);
                    writer.WriteLine(item._value);
                    writer.WriteLine(item._rarity);
                }
            }
            Console.WriteLine("Inventory Succesfully saved!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving Inventory: {ex.Message}");
        }
    }

    public void LoadInventory(Inventory inventory, string filename, Player player)
    {
         if (!File.Exists(filename))
        {
            Console.WriteLine("No file found. Starting a fresh inventory!");
            return;
        }

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                player._gold = int.Parse(reader.ReadLine());

                inventory.currentInventory.Clear();

                int itemCount = int.Parse(reader.ReadLine());

                for (int i = 0; i < itemCount; i++)
                {
                    string name = reader.ReadLine();
                    int value = int.Parse(reader.ReadLine());
                    Rarity rarity = Enum.Parse<Rarity>(reader.ReadLine());

                    inventory.currentInventory.Add(new Item(name, value, rarity));
                }
            }
            Console.WriteLine("Inventory succesfully loaded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading inventory: {ex.Message}");
        }
    }
}