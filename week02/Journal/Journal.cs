using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToSaveString());
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"File {filename} does not exist.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromSaveString(line);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Journal loaded from {filename}");
    }
}
