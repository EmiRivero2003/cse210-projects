using System;

public class Running : ExerciseTracking
{
    private double _distanceKm;

    public Running(DateTime date, int minutes, double distanceKm) : base(date, minutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistanceKm()
    {
        return _distanceKm;
    }

    public override double GetSpeedKph()
    {
        return (_distanceKm / Minutes) * 60.0;
    }

    public override double GetPaceMinPerKm()
    {
        return _distanceKm <= 0 ? 0 : Minutes / _distanceKm;
    }
}