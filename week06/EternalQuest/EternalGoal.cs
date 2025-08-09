using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string GetStatus()
    {
        return $"[ ] {Name}";
    }

    public override string ToStorageLine()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }
}