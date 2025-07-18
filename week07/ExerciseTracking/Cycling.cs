using System;

public class Cycling : Activity
{
    private double _speed; // in kilometers per hour

    public Cycling(string date, int length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * Length) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}
