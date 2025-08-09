using System;

public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete)
    {
        _completed = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return _completed ? "[X] " + Name : "[ ] " + Name;
    }

    public override string ToStorageLine()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{_completed}";
    }
}