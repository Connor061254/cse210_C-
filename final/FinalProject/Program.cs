using System;

class Program
{
    private static bool _isLooping = true;
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        Shop shop = new Shop();
        LootBox lootBox = new LootBox();
        while (_isLooping == true)
        {
             Console.WriteLine("""
            Please select one of the options below:
        
            1. Shop
            2. Lootbox
            3. Inventory
            4. Save
            5. Load
            6. Quit
            """);

            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                shop.Welcome(inventory);
                break;

                case 2:
                Console.Clear();
                lootBox.showLootbox();
                break;

                case 3:
                Console.Clear();
                inventory.DisplayInventory();
                break;

                case 4:
                Console.WriteLine("what is the filename you would like to save it too?");
                string filename = Console.ReadLine();
                inventory.SaveInventory(filename);
                break;

                case 5:
                Console.WriteLine("What is the filename to load too?");
                string LFilename = Console.ReadLine();
                inventory.LoadInventory(LFilename);
                break;

                case 6:
                _isLooping = false;
                break;
                // for testing
                case 7:
                inventory._coins += 10000;
                break;
            }
        }
       
    }
}