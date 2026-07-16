using System.Dynamic;

public class Inventory
{   
    public List<Item> currentInventory = new List<Item>();
    public int _coins {get; set;}

    public void DisplayInventory()
    {
        Console.WriteLine("Your Inventory: ");

        Console.WriteLine($"You have {_coins} gold");

        Console.WriteLine("Here are your Items:");
        int n = 1;
        for (int i = 0; i < currentInventory.Count; i++)
        {
            Console.WriteLine($"{n}. {currentInventory[i]}");
            n++;
        }
    }

    public void RemoveItem(int itemToRemove)
    {
        currentInventory.RemoveAt(itemToRemove);
    }

    public void SaveInventory(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_coins);

                writer.WriteLine(currentInventory.Count);

                foreach(Item item in currentInventory)
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

    public void LoadInventory(string filename)
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
                _coins = int.Parse(reader.ReadLine());

                currentInventory.Clear();

                int itemCount = int.Parse(reader.ReadLine());

                for (int i = 0; i < itemCount; i++)
                {
                    string name = reader.ReadLine();
                    int value = int.Parse(reader.ReadLine());
                    Rarity rarity = Enum.Parse<Rarity>(reader.ReadLine());

                    currentInventory.Add(new Item(name, value, rarity));
                }
            }
            Console.WriteLine("Inventory succesfully loaded!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading inventory: {ex.Message}");
        }
    }

    public void CombineItems(Rarity rarityToCombine, LootBox lootBox)
    {
        List<Item> matchingItems = currentInventory.FindAll(item => item._rarity == rarityToCombine);

        if (matchingItems.Count < 3)
        {
            Console.WriteLine("You need three items of the same rarity");
            return;
        }

        if (rarityToCombine == Rarity.Mythic)
        {
            Console.WriteLine("You cant merge mythic items");
            return;
        }

        Rarity nextRarity = rarityToCombine + 1;

        for (int i = 0; i < 3; i++)
        {
            currentInventory.Remove(matchingItems[i]);
        }

        Item upgradedItem = lootBox.GetRarityItem(nextRarity);

        
        if(upgradedItem != null)
        {
            currentInventory.Add(upgradedItem);
            Console.WriteLine($"Success! you have combined 3 {rarityToCombine} items and crafted {upgradedItem._itemName} {nextRarity}!");
        }
        else
        {
            Console.WriteLine($"Error: Could not find any items of {nextRarity} rarity");
        }
    }
}