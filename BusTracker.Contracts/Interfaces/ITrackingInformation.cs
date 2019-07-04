namespace BusTracker.Contracts.Interfaces
{
    using GeoCoordinatePortable;

    public interface ITrackingInformation
    {
        int Id { get; }

        int RouteId { get; }

        GeoCoordinate GeoPosition { get; }

        string RegistrationNumber { get; }

        bool? HasLowLanding { get; }

        bool? HasHingeConnection { get; }
    }
}
