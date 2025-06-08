public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStatus() => $"[{"X"}] {_name} ({_description})";

    public override string Serialize() => $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";

    public new static SimpleGoal Deserialize(string data)
    {
        var parts = data.Split(",");
        var goal = new SimpleGoal(parts[0], parts[1], int.Parse(parts[2]));
        goal._isComplete = bool.Parse(parts[3]);
        return goal;
    }
}
