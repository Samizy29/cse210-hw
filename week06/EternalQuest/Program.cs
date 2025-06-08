using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new();
    static int score = 0;

    static void Main()
    {
        string input;
        do
        {
            Console.Clear();
            Console.WriteLine($"Score: {score}\n");
            Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            Console.Write("Select an option: ");
            input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
            }
        } while (input != "6");
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
        Console.Write("Select goal type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int pts = int.Parse(Console.ReadLine());

        Goal goal = type switch
        {
            "1" => new SimpleGoal(name, desc, pts),
            "2" => new EternalGoal(name, desc, pts),
            "3" => CreateChecklistGoal(name, desc, pts),
            _ => null
        };

        if (goal != null)
        {
            goals.Add(goal);
            Console.WriteLine("Goal added!");
        }
    }

    static ChecklistGoal CreateChecklistGoal(string name, string desc, int pts)
    {
        Console.Write("Target count: ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("Bonus points: ");
        int bonus = int.Parse(Console.ReadLine());
        return new ChecklistGoal(name, desc, pts, target, bonus);
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        using StreamWriter writer = new("goals.txt");
        writer.WriteLine(score);
        foreach (var goal in goals)
        {
            writer.WriteLine(goal.Serialize());
        }
        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;

        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);
        goals.Clear();

        foreach (var line in lines[1..])
        {
            goals.Add(Goal.Deserialize(line));
        }

        Console.WriteLine("Goals loaded.");
    }

    static void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal to record: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < goals.Count)
        {
            int points = goals[index].RecordEvent();
            score += points;
            Console.WriteLine($"You earned {points} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }

        Console.ReadLine();
    }
}
