using System;

class Program
{
    private static bool _isLooping = true;
    static void Main(string[] args)
    {
        Inventory inventory = new Inventory();
        Shop shop = new Shop();
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

                break;

                case 3:
                Console.Clear();
                inventory.DisplayInventory();
                break;

                case 4:
                
                break;

                case 5: 

                break;

                case 6:
                _isLooping = false;
                break;
            }
        }
       
    }
}