public class Player
{
    public int _gold {get; set;}
    public string _name {get; set;}
    public Inventory inventory {get; set;}

    public Player(string name, int startingGold)
    {
        _gold = startingGold;
        _name = name;

        inventory = new Inventory();
    }
}