using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person you interacted with today?",
        "What was the best part of your day?",
        "How did you see the hand of the Lord in your life today?",
        "What was the strongest emotion you felt today?",
        "If you had one thing you could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("How are you feeling today? (Your mood): ");
        string mood = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        JournalEntry entry = new JournalEntry(date, prompt, response, mood);
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.Date);
                writer.WriteLine(entry.Mood);
                writer.WriteLine(entry.Prompt);
                writer.WriteLine(entry.Response);
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        for (int i = 0; i < lines.Length; i += 4)
        {
            string date = lines[i];
            string mood = lines[i + 1];
            string prompt = lines[i + 2];
            string response = lines[i + 3];

            JournalEntry entry = new JournalEntry(date, prompt, response, mood);
            entries.Add(entry);
        }
        Console.WriteLine("Journal loaded successfully.");
    }
}
