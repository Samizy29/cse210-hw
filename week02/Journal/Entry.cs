using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string date, string prompt, string response)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
    }

    public override string ToString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nResponse: {_response}\n";
    }

    // Used for saving/loading entries with a custom delimiter "|~|"
    public string ToSaveString()
    {
        // Replace any occurrence of the delimiter inside the strings to avoid breaking the format
        string safePrompt = _prompt.Replace("|~|", " ");
        string safeResponse = _response.Replace("|~|", " ");
        return $"{_date}|~|{safePrompt}|~|{safeResponse}";
    }

    public static Entry FromSaveString(string line)
    {
        string[] parts = line.Split(new string[] { "|~|" }, StringSplitOptions.None);
        if (parts.Length == 3)
        {
            return new Entry(parts[0], parts[1], parts[2]);
        }
        else
        {
            return null;
        }
    }
}
