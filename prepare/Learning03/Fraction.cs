public class Fraction
{
    private int top;
    private int bot;

    public int health {get; set;}
    public Fraction()
    {
        health = 100;
    }
    public Fraction(int topNumber)
    {
        top = topNumber;
        bot = 1;
    }
    public Fraction(int topNumber, int botNumber)
    {
        top = topNumber;
        bot = botNumber;
    }

    public void SetTop(int topOne)
    {
        top = topOne;
    }
    public void SetBot(int botOne)
    {
        bot = botOne;
    }
    public int GetBot()
    {
        return bot;
    }
    public int GetTop()
    {
        return top;
    }
}
