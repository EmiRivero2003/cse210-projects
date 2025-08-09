using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, bool isComplete, int targetCount, int currentCount, int bonus) : base(name, description, points, isComplete)
    {
        _targetCount = targetCount;
        _currentCount = currentCount;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount >= _targetCount)
            {
                IsComplete = true;
                return Points + _bonus;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return (IsComplete ? "[X] " : "[ ] ") + $"{Name} -- Completed {_currentCount}/{_targetCount}";
    }

    public override string ToStorageLine()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_currentCount}|{_targetCount}|{_bonus}|{IsComplete}";
    }
}