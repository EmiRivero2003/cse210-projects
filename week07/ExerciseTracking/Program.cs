using System;


class Program
{
    static void Main(string[] args)
    {
        var activities = new List<ExerciseTracking>
        {
            new Running(new DateTime(2025, 8, 10), 30, 4.8),
            new Cycling(new DateTime(2025, 8, 11), 40, 24.0),
            new Swimming(new DateTime(2025, 8, 12), 25, 30)
        };

        foreach (var a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}