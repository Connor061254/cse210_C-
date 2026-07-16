public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic

}

public class Item
{
    public int _value {get; set;}

    public Rarity _rarity {get; set;}
    
    public string _itemName {get; set;}

    public Item(string name, int value, Rarity rarity)
    {
        _itemName = name;
        _value = value;
        _rarity = rarity;
    }

    public override string ToString()
    {
        return $"{_itemName} {_rarity} {_value} Gold";
    }
}