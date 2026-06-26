public class EternalGoal : Goal
{
    public EternalGoal(string name, int points, string description) : base(name, points, description)
    {
        
    }

    public override void RecordEvent()
    {

    }

    public override string GetDetailString()
    {
        string checkbox = _isComplete ? "[x]" : "[ ]";
        return $"{checkbox} {_name} ({_description})";
    }
}