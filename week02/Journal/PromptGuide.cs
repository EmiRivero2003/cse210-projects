using System;

public class PromptGuide
{
    private List<string> _prompts = new List<string>();
    private string _promptsFilePath = "prompts.txt";

    public PromptGuide()
    {
        if (File.Exists(_promptsFilePath))
        {
            _prompts = new List<string>(File.ReadAllLines(_promptsFilePath));
        }
        else
        {
            _prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }
    }

    public string SelectPrompt()
    {
        Random rnd = new Random();
        int index = rnd.Next(_prompts.Count);
        return _prompts[index];
    }
}