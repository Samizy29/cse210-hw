public class JournalEntry
{
    public string Date { get; }
    public string Prompt { get; }
    public string Response { get; }
    public string Mood { get; }

    public JournalEntry(string date, string prompt, string response, string mood)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        Mood = mood;
    }

    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"Response: {Response}");
        Console.WriteLine("---------------------------------");
    }
}
