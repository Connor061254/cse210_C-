public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    public ChecklistGoal(string name, int points, string description, int target) : base(name, points, description)
    {
        _targetCount = target;
        _currentCount = 0;
    }

    public override void RecordEvent()
    {
        _currentCount++;

        if (_currentCount >= _targetCount)
        {
            _isComplete = true;
        }
    }

    public override string GetDetailString()
    {
        string checkbox = _isComplete ? "[x]" : "[ ]";
        return $"{checkbox} {_name} ({_description} -- Currently completed: {_currentCount}/{_targetCount})";
    }

    public string GetDetailsForSaving() => $"{_currentCount}, {_targetCount}";
}
