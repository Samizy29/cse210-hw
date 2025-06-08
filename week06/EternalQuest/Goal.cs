public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string Serialize();
    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split(":");
        string type = parts[0];
        string details = parts[1];

        return type switch
        {
            "SimpleGoal" => SimpleGoal.Deserialize(details),
            "EternalGoal" => EternalGoal.Deserialize(details),
            "ChecklistGoal" => ChecklistGoal.Deserialize(details),
            _ => null,
        };
    }
}
