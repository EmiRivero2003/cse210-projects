using System;

public class Video
{
    private string _title;
    private string _author;
    private int _length; //Time in seconds
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Lenght: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");
        Console.WriteLine("Comments: ");
        foreach (Comment c in _comments)
        {
            Console.WriteLine($" - {c.GetDisplayComment()}");
        }
        Console.WriteLine();
    }
}