using System.Dynamic;

public class Inventory
{   
    public List<Item> currentInventory = new List<Item>();
    public int _coins {get; set;}

    public void DisplayInventory()
    {
        Console.WriteLine("Your Inventory: ");

        for (int i = 0; i < currentInventory.Count; i++)
        {
            Console.WriteLine(currentInventory[i]);
        }
        
    }
}