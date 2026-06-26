public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, string description) : base(name, points, description)
    {
        
    }

    public override void RecordEvent()
    {
        _isComplete = true;
    }

    public override string GetDetailString()
    {
        string checkbox = _isComplete ? "[x]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }
}