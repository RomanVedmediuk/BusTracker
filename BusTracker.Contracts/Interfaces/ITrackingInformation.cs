namespace BusTracker.Contracts.Interfaces
{
    public interface ITrackingInformation
    {
        int Id { get; }

        int RouteId { get; }

        IGeoPosition GeoPosition { get; }

        string RegistrationNumber { get; }

        bool? HasLowLanding { get; }

        bool? HasHingeConnection { get; }
    }
}
