using System;

class Program
{
    static string[] _prompts = new string[]
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    static Journal _journal = new Journal();
    static Random _random = new Random();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to your Journal Program!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option (1-5): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    _journal.Display();
                    break;
                case "3":
                    SaveJournal();
                    break;
                case "4":
                    LoadJournal();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please enter a number 1-5.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        string prompt = _prompts[_random.Next(_prompts.Length)];
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry entry = new Entry(date, prompt, response);
        _journal.AddEntry(entry);

        Console.WriteLine("Entry added.");
    }

    static void SaveJournal()
    {
        Console.Write("Enter filename to save journal (e.g., journal.txt): ");
        string filename = Console.ReadLine();
        try
        {
            _journal.Save(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter filename to load journal (e.g., journal.txt): ");
        string filename = Console.ReadLine();
        try
        {
            _journal.Load(filename);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}
