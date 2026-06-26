public abstract class Goal
{
    public string _name {get; private set;}
    public int _points {get; private set;}
    public string _description {get; private set;}

    public bool _isComplete {get; set;}

    public Goal(string name, int points, string description)
    {
        _name = name;
        _points = points;
        _description = description;
    }

    public abstract void RecordEvent();

    public abstract string GetDetailString();
}