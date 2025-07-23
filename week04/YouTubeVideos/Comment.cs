using System;

public class Comment
{
    private string _personName;
    private string _commentText;

    public Comment(string _personName, string _commentText)
    {
        this._personName = _personName;
        this._commentText = _commentText;
    }

    public string GetDisplayComment()
    {
        return $"{_personName}: {_commentText}";
    }
}