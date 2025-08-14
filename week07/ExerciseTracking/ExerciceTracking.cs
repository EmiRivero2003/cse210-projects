using System;

public abstract class ExerciseTracking
{
    private DateTime _date;
    private int _minutes;

    protected ExerciseTracking(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistanceKm();
    public abstract double GetSpeedKph();
    public abstract double GetPaceMinPerKm();

    public virtual string GetSummary()
    {
        double d = GetDistanceKm();
        double s = GetSpeedKph();
        double p = GetPaceMinPerKm();

        string name = GetType().Name;

        return $"{Date:dd MMM yyyy} {name} ({Minutes} min): " +
                $"Distance {d:0.0} Km, Speed {s:0.0} kph, Pace {p:0.0} min per km";
    }
}