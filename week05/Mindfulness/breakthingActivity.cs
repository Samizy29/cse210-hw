using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", 
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 
               0)
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            Countdown(4);
            Console.WriteLine();

            elapsed += 8;
        }
        DisplayEndingMessage();
    }
}
