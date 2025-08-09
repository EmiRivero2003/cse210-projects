using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine($"Total Score: {manager.GetTotalPoints()}");
            Console.WriteLine("1) Create Goal");
            Console.WriteLine("2) List Goals");
            Console.WriteLine("3) Record Event");
            Console.WriteLine("4) Save Goals");
            Console.WriteLine("5) Load Goals");
            Console.WriteLine("6) Quit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine()?.Trim() ?? "";

            switch (choice)
            {
                case "1":
                    CreateGoalInteractive(manager);
                    break;
                case "2":
                    ListGoalsInteractive(manager);
                    break;
                case "3":
                    RecordEventInteractive(manager);
                    break;
                case "4":
                    SaveInteractive(manager);
                    break;
                case "5":
                    LoadInteractive(manager);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    static void CreateGoalInteractive(GoalManager manager)
    {
        Console.WriteLine();
        Console.WriteLine("Create Goal");
        Console.WriteLine("a) Simple");
        Console.WriteLine("b) Eternal");
        Console.WriteLine("c) Checklist");
        Console.Write("Type: ");
        string type = Console.ReadLine()?.Trim().ToLower() ?? "";

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";
        int points = ReadInt("Points: ");

        bool isComplete = false;

        switch (type)
        {
            case "a":
            case "simple":
            {
                var goal = new SimpleGoal(name, description, points, isComplete);
                manager.AddGoal(goal);
                Console.WriteLine("Simple goal created.");
                break;
            }
            case "b":
            case "eternal":
            {
                var goal = new EternalGoal(name, description, points, isComplete);
                manager.AddGoal(goal);
                Console.WriteLine("Eternal goal created.");
                break;
            }
            case "c":
            case "checklist":
            {
                int target = ReadInt("Target count: ");
                int bonus  = ReadInt("Bonus on completion: ");
                int current = 0;
                var goal = new ChecklistGoal(name, description, points, isComplete, target, current, bonus);
                manager.AddGoal(goal);
                Console.WriteLine("Checklist goal created.");
                break;
            }
            default:
                Console.WriteLine("Unknown goal type.");
                break;
        }
    }

    static void ListGoalsInteractive(GoalManager manager)
    {
        Console.WriteLine();
        Console.WriteLine("Your Goals:");
        List<string> lines = manager.ListGoals();
        if (lines.Count == 0)
        {
            Console.WriteLine("(no goals yet)");
            return;
        }

        for (int i = 0; i < lines.Count; i++)
        {
            Console.WriteLine($"{i}: {lines[i]}");
        }
    }

    static void RecordEventInteractive(GoalManager manager)
    {
        Console.WriteLine();
        ListGoalsInteractive(manager);
        if (manager.Count == 0) return;

        int index = ReadInt("Enter the goal index to record: ");
        int earned = manager.RecordEvent(index);
        if (earned > 0)
        {
            Console.WriteLine($"You earned +{earned} points! Total: {manager.GetTotalPoints()}");
        }
        else
        {
            Console.WriteLine("No points awarded (invalid index or goal already completed).");
        }
    }

    static void SaveInteractive(GoalManager manager)
    {
        Console.Write("Filename to save (e.g., goals.txt): ");
        string filename = Console.ReadLine() ?? "goals.txt";
        try
        {
            manager.Save(filename);
            Console.WriteLine("Saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Save failed: {ex.Message}");
        }
    }

    static void LoadInteractive(GoalManager manager)
    {
        Console.Write("Filename to load: ");
        string filename = Console.ReadLine() ?? "goals.txt";
        try
        {
            manager.Load(filename);
            Console.WriteLine("Loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Load failed: {ex.Message}");
        }
    }

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();
            if (int.TryParse(s, out int value)) return value;
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}