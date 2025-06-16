using System;

public abstract class Activity
{
    private string _date;
    private int _length; // in minutes

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    public string Date => _date;
    public int Length => _length;

    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in kph
    public abstract double GetPace();     // in min per km

    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_length} min): Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}
