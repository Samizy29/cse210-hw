public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent() => _points;

    public override bool IsComplete() => false;

    public override string GetStatus() => $"[∞] {_name} ({_description})";

    public override string Serialize() => $"EternalGoal:{_name},{_description},{_points}";

    public new static EternalGoal Deserialize(string data)
    {
        var parts = data.Split(",");
        return new EternalGoal(parts[0], parts[1], int.Parse(parts[2]));
    }
}
