using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("Emiliano Rivero", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Alejandro Rivero", "Fractions", "7.3", "8-19");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Leticia Novo", "Cold War", "The Causes of Cold War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}