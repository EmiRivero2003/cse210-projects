using System;

public class Entry
{
    private string _prompt;
    private string _entryText;
    private string _entryDate;

    public Entry(string prompt, string entryText)
    {
        _prompt = prompt;
        _entryText = entryText;
        _entryDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
    }

    public string GetDisplayText()
    {
        return $"[{_entryDate}]\nPrompt: {_prompt}\nEntry: {_entryText}\n";
    }

    public string GetSaveText()
    {
        return $"{_entryDate}|{_prompt}|{_entryText}";
    }

    public static Entry FromSavedText(string line)
    {
        var parts = line.Split("|");
        return new Entry(parts[1], parts[2]) { _entryDate = parts[0] };
    }
}