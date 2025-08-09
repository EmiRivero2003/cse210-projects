using System;

public class GoalManager
{
    private readonly List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0;

    public void AddGoal(Goal goal)
    {
        if (goal != null)
        {
            _goals.Add(goal);
        }
    }

    public List<string> ListGoals()
    {
        List<string> list = new List<string>();
        foreach (Goal goal in _goals)
        {
            list.Add(goal.GetStatus());
        }
        return list;
    }

    public int GetTotalPoints() => _totalPoints;

    public int RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordEvent();
            _totalPoints += pointsEarned;
            return pointsEarned;
        }
        return 0;
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"TotalPoints={_totalPoints}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.ToStorageLine());
            }
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length > 0 && lines[0].StartsWith("TotalPoints="))
        {
            _totalPoints = int.Parse(lines[0].Split('=')[1]);
        }

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = ParseLine(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
    }

    private Goal ParseLine(string line)
    {
        string[] parts = line.Split('|');
        string type = parts[0];

        switch (type)
        {
            case "SimpleGoal":
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
            case "EternalGoal":
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), false);
            case "ChecklistGoal":
                return new ChecklistGoal(
                    parts[1], parts[2],
                    int.Parse(parts[3]), bool.Parse(parts[7]),
                    int.Parse(parts[5]), int.Parse(parts[4]), int.Parse(parts[6])
                );
            default:
                return null;
        }
    }

    public int Count => _goals.Count;
    public Goal GetAt(int index) => _goals[index];
}