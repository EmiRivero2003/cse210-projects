using System;

public class Cycling : ExerciseTracking
{
    private double _speedKph;

    public Cycling(DateTime date, int minutes, double speedKph) : base(date, minutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistanceKm()
    {
        return _speedKph * (Minutes / 60.0);
    }

    public override double GetSpeedKph()
    {
        return _speedKph;
    }

    public override double GetPaceMinPerKm()
    {
        return _speedKph <= 0 ? 0 : 60.0 / _speedKph; 
    }
}