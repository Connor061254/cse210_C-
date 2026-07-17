using System;

class Program
{
    private static bool _isLooping = true;
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        Shop shop = new Shop();
        LootBox lootBox = new LootBox();
        SaveSystem saveSystem = new SaveSystem();
        Player player = new Player("Hero", 1500);
        while (_isLooping == true)
        {
            Console.Clear();
            Menu.DisplayHeader("LootBox RPG");
            Menu.DisplayMainMenu();
            int response = Menu.GetNumberInput("Enter your choice: ");

            switch (response)
            {
                case 1:
                shop.Welcome(player);
                break;

                case 2:
                Console.Clear();
                lootBox.showLootbox();
                Console.WriteLine("\nPress Enter to return to the main menu");
                Console.ReadLine();
                break;

                case 3:
                Console.Clear();
                inventory.DisplayInventory(player);
                Console.WriteLine("\nPress Enter to return to the main menu");
                Console.ReadLine();
                break;

                case 4:
                Console.WriteLine("what is the filename you would like to save it too?");
                string filename = Console.ReadLine();
                saveSystem.SaveInventory(inventory, filename, player);
                Console.WriteLine("\nPress Enter to return to the main menu");
                Console.ReadLine();
                break;

                case 5:
                Console.WriteLine("What is the filename to load too?");
                string LFilename = Console.ReadLine();
                saveSystem.LoadInventory(inventory, LFilename, player);
                Console.WriteLine("\nPress Enter to return to the main menu");
                Console.ReadLine();
                break;

                case 6:
                _isLooping = false;
                break;
                // for testing
                case 7:
                player._gold += 10000;
                break;
            }
        }
       
    }
}