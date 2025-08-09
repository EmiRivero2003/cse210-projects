using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    protected bool IsComplete
    {
        get => _isComplete;
        set => _isComplete = value;
    }

    protected Goal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public abstract int RecordEvent();

    public virtual string GetStatus()
    {
        return IsComplete ? $"[X] {Name}" : $"[ ] {Name}";
    }

    public virtual string ToStorageLine()
    {
        return $"{Name}|{Description}|{Points}|{IsComplete}";
    }
}