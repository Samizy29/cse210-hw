using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test single shape classes
        Square sq = new Square("Red", 4);
        Console.WriteLine($"Square Color: {sq.Color}, Area: {sq.GetArea()}");

        Rectangle rect = new Rectangle("Blue", 5, 3);
        Console.WriteLine($"Rectangle Color: {rect.Color}, Area: {rect.GetArea()}");

        Circle circ = new Circle("Green", 2.5);
        Console.WriteLine($"Circle Color: {circ.Color}, Area: {circ.GetArea():F2}");

        // Build a list of shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(sq);
        shapes.Add(rect);
        shapes.Add(circ);

        Console.WriteLine("\nIterating over shapes list:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}
