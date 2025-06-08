public class Shape
{
    private string _color;

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public Shape(string color)
    {
        _color = color;
    }

    // Virtual method to be overridden by derived classes
    public virtual double GetArea()
    {
        return 0;
    }
}
