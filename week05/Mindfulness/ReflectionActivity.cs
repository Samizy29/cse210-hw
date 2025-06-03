using System;
using System.Threading;

public class ReflectionActivity : Activity
{
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] _questions = {
        "Why was this experience meaningful to you?",
        "What did you learn from this experience?",
        "How did you get started?",
        "How did you feel afterward?",
        "What made this experience different?",
        "How will you remember this moving forward?"
    };

    public ReflectionActivity() 
        : base("Reflection Activity", 
               "This activity will help you reflect on times when you have shown strength and resilience.", 
               0)
    { }

    public override void Run()
    {
        DisplayStartingMessage();
        Random rand = new Random();
        Console.WriteLine(_prompts[rand.Next(_prompts.Length)]);
        PauseWithSpinner(4);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = _questions[rand.Next(_questions.Length)];
            Console.WriteLine($"> {question}");
            PauseWithSpinner(6);
        }

        DisplayEndingMessage();
    }
}
