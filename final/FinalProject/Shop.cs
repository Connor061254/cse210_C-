public class Shop
{
    private bool _isLooping = true;

    private bool _hasOpened = false;

    private int _numberOfLootboxes = 0;

    private Inventory GetInventory;
    public void Welcome(Inventory inventory)
    {
        LootBox lootBox = new LootBox();
        GetInventory = inventory;
        Console.Clear();
        _isLooping = true;

        
        if(GetInventory._coins == 0 && _hasOpened == false)
        {
            GetInventory._coins = 1500;
        }
        Console.WriteLine("Welcome to the shop! Here you can purchase and open lootboxes, or trade in equipment for better equipment and coins,");
        Console.WriteLine(" ");
        Console.WriteLine($"You have {GetInventory._coins} gold");
        

        while(_isLooping == true)
        {
            Console.WriteLine("""
            Please select what you would like to do:
        
            1. Purchase Lootbox 500 gold
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
                if(GetInventory._coins >= 500)
                    {
                        ++_numberOfLootboxes;
                        Console.WriteLine($"You purchased 1 lootbox, you now have {_numberOfLootboxes} lootboxes");
                        GetInventory._coins -= 500;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough gold to purchase a lootbox");
                    }
               
                break;

                case 2:
                if(_numberOfLootboxes > 0)
                    {
                        inventory.currentInventory.Add(lootBox.GetRandomItem());
                        _hasOpened = true;
                        _numberOfLootboxes -= 1;
                        Console.WriteLine("You have opened a lootbox, please check your inventory to see what you got!");
                    }
                    else
                    {
                        Console.WriteLine("You have no Lootboxes");
                    }

                break;

                case 3:
                Console.Clear();
                GetInventory.DisplayInventory();
                Console.WriteLine(" ");
                Console.WriteLine("which rarity would you like to combine? (3 of one rarity = 1 item of a higher rarity)");
                Console.WriteLine("0. Common\n1. Uncommon\n2. Rare\n3. Epic\n4. Legendary");
                int rarityChoice = int.Parse(Console.ReadLine());
                
                if(rarityChoice >= 0 && rarityChoice <= 4)
                    {
                        Rarity selectedRarity = (Rarity)rarityChoice;
                        GetInventory.CombineItems(selectedRarity, lootBox);
                    }
                break;

                case 4:
                Console.Clear();
                GetInventory.DisplayInventory();
                Console.WriteLine("Which item would you like to sell? Or type 0 to go back to the menu");
                int value = int.Parse(Console.ReadLine());
                int indexToRemove = value - 1;
                
                    if(indexToRemove >= 0 && indexToRemove < GetInventory.currentInventory.Count)
                    {
                        int goldGained = GetInventory.currentInventory[indexToRemove]._value;
                        GetInventory._coins += goldGained;
                        GetInventory.RemoveItem(indexToRemove);
                        Console.WriteLine($"+{goldGained} gold");
                    }
                    else if(value == 0)
                    {
                       _isLooping = false;
                    }
                    else
                    {
                         Console.WriteLine("Please enter a valid number");
                    }
                
                break;

                case 5:
                _isLooping = false;
                break;
            }
        }
        
    }
}