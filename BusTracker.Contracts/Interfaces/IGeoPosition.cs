namespace BusTracker.Contracts.Interfaces
{
    public interface IGeoPosition
    {
        double? Latitude { get; }

        double? Longitude { get; }

        int? Azimuth { get; }

        int Speed { get; }
    }
}