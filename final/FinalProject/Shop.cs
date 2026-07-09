public class Shop
{
    private bool _isLooping = true;

    private int _numberOfLootboxes = 0;
    public void Welcome(Inventory inventory)
    {
        LootBox lootBox = new LootBox();
        Console.Clear();
        _isLooping = true;
        Console.WriteLine("Welcome to the shop! Here you can purchase and open lootboxes, or trade in equipment for better equipment and coins,");

        while(_isLooping == true)
        {
            Console.WriteLine("""
            Please select what you would like to do:
        
            1. Purchase Lootbox
            2. Open Lootbox
            3. trade in equipment
            4. Sell Equipment
            5. Exit the shop
            """);

            int response = int.Parse(Console.ReadLine());

            switch (response)
            {
                case 1:
                Console.Clear();
                inventory.currentInventory.Add(lootBox.GetRandomItem());
                ++_numberOfLootboxes;
                Console.WriteLine($"You purchased 1 lootbox, you now have {_numberOfLootboxes} lootboxes");
                break;

                case 2:

                break;

                case 3:

                break;

                case 4:

                break;

                case 5:
                _isLooping = false;
                break;
            }
        }
        
    }
}