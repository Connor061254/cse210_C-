using System.Dynamic;

public class Inventory
{   
    public List<Item> currentInventory = new List<Item>();

    public void DisplayInventory(Player player)
    {
        Console.WriteLine("Your Inventory: ");

        Console.WriteLine($"You have {player._gold} gold");

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