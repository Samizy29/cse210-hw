public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            return _currentCount == _targetCount ? _points + _bonus : _points;
        }
        return 0;
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        $"[{(IsComplete() ? "X" : " ")}] {_name} ({_description}) -- {_currentCount}/{_targetCount}";

    public override string Serialize() =>
        $"ChecklistGoal:{_name},{_description},{_points},{_bonus},{_targetCount},{_currentCount}";

    public new static ChecklistGoal Deserialize(string data)
    {
        var parts = data.Split(",");
        var goal = new ChecklistGoal(parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]), int.Parse(parts[3]));
        goal._currentCount = int.Parse(parts[5]);
        return goal;
    }
}
