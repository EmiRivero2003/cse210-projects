using System;

public class Scripture
{
    private List<Word> _scripture;
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _scripture = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            _scripture.Add(new Word(word));
        }
    }

    public void Display()
    {
        _reference.Display();

        foreach (Word word in _scripture)
        {
            word.Display();
        }

        Console.WriteLine();
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int wordsToHide = 3;

        int attempts = 0;
        while (wordsToHide > 0 && attempts < 100)
        {
            int index = random.Next(_scripture.Count);
            Word word = _scripture[index];

            if (!word.isHidden())
            {
                word.Hide();
                wordsToHide--;
            }

            attempts++;
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _scripture)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }
    

}

