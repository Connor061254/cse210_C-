public static class Menu
{
    public static void DisplayHeader(string title)
    {
        Console.WriteLine("=====================================");
        Console.WriteLine($"      {title.ToUpper()}      ");
        Console.WriteLine("=====================================");
    }

    public static void DisplayMainMenu()
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
    }

    public static void DisplayShopMenu()
    {
         Console.WriteLine("""
            Please select what you would like to do:
        
            1. Purchase Lootbox 500 gold
            2. Open Lootbox
            3. trade in equipment
            4. Sell Equipment
            5. Exit the shop
            """);
    }

    public static int GetNumberInput(string prompt)
    {
        int choice;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out choice))
            {
                return choice;
            }

            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }
}