public class LootBox
{
    public List<Item> AllItems = new List<Item>
    {
        new Item("BrokenStick", 2, Rarity.Common),
        new Item("RippedPage", 4, Rarity.Common),
        new Item("OldBoot", 5, Rarity.Common),
        new Item("DullPebble", 8, Rarity.Common),
        new Item("ClothScrap", 12, Rarity.Common),
        new Item("CopperOre", 15, Rarity.Common),
        new Item("RustyNail", 18, Rarity.Common),
        new Item("BentFork", 20, Rarity.Common),
        new Item("CrackedVial", 22, Rarity.Common),
        new Item("RustyDagger", 25, Rarity.Common),
        new Item("SmallHealthPotion", 30, Rarity.Common),
        new Item("ThreadbareCap", 35, Rarity.Common),
        new Item("WoodenShield", 45, Rarity.Common),
        new Item("MuddyBandage", 50, Rarity.Common),

        new Item("HardenedLeatherGloves", 75, Rarity.Uncommon),
        new Item("PolishedStone", 85, Rarity.Uncommon),
        new Item("MediumManaPotion", 100, Rarity.Uncommon),
        new Item("IronHelmet", 125, Rarity.Uncommon),
        new Item("FlintAndSteel", 140, Rarity.Uncommon),
        new Item("LeatherBoots", 150, Rarity.Uncommon),
        new Item("SteelSword", 200, Rarity.Uncommon),
        new Item("SilverRing", 250, Rarity.Uncommon),
        new Item("ReinforcedShield", 300, Rarity.Uncommon),
        new Item("HuntersBow", 350, Rarity.Uncommon),

        new Item("SpikedBarricade", 500, Rarity.Rare),
        new Item("ApprenticeWand", 750, Rarity.Rare),
        new Item("PegasusFeather", 900, Rarity.Rare),
        new Item("ShadowCloak", 1100, Rarity.Rare),
        new Item("EnchantedBow", 1350, Rarity.Rare),

        new Item("PhoenixDown", 3500, Rarity.Epic),
        new Item("ThunderHammer", 8000, Rarity.Epic),
        new Item("DragonScaleMail", 9000, Rarity.Epic),

        new Item("ChronoStaff", 50000, Rarity.Legendary),
        new Item("Excalibur", 75000, Rarity.Legendary),

        new Item("CosmicInfinityBlade", 500000, Rarity.Mythic)
    };

    public Item GetRandomItem()
    {
        Random random = new Random();
        int index = random.Next(AllItems.Count);
        return AllItems[index];
    }

    public Item GetRarityItem(Rarity TargetRarity)
    {
        List<Item> matchingItems = AllItems.FindAll(item => item._rarity == TargetRarity);

        if(matchingItems.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int index = random.Next(matchingItems.Count);
        return matchingItems[index];
    }

    public void showLootbox()
    {
        Console.WriteLine("""
        Drop Chances:

        Common: Drop Chance 40%
        Uncommon: Drop Chance 28.57%
        Rare: Drop Chance 14.29%
        Epic: Drop Chance 8.57%
        Legendary: Drop Chance 5.71%
        Mythic: Drop Chance 2.86%
        """);
        Console.WriteLine(" ");
        Console.WriteLine("Available items:");
        int n = 1;
        for(int i = 0; i < AllItems.Count; i++)
        {
            Console.WriteLine($"{n}. {AllItems[i]}");
            n++;
        }
        Console.WriteLine(" ");
    }
}