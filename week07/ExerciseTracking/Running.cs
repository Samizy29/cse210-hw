using System;

public class Running : Activity
{
    private double _distance; // in kilometers

    public Running(string date, int length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / Length) * 60;
    }

    public override double GetPace()
    {
        return Length / _distance;
    }
}
