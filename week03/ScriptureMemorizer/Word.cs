using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;

    }

    public bool isHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string HideWord()
    {
        return new string('_', _text.Length);
    }

    public void Display()
    {
        if (_isHidden)
        {
            Console.Write(HideWord() + " ");
        }
        else
        {
            Console.Write(_text + " ");
        }
    }
}