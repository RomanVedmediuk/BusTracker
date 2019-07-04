namespace BusTracker.Contracts.Interfaces
{
    using GeoCoordinatePortable;

    public interface IStationInformation
    {
        int Id { get;}

        string Name { get;}

        GeoCoordinate Location { get;}
    }
}