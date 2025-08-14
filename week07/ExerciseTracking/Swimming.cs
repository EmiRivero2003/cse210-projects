using System;

public class Swimming : ExerciseTracking
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistanceKm()
    {
        return _laps * 0.05;
    }

    public override double GetSpeedKph()
    {
        double distance = GetDistanceKm();
        return distance <= 0 ? 0 : (distance / Minutes) * 60.0;
    }

    public override double GetPaceMinPerKm()
    {
        double distance = GetDistanceKm();
        return distance <= 0 ? 0 : Minutes / distance;
    }
}