namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Linq;
    using BusTracker.Contracts.Interfaces;
    using GeoCoordinatePortable;

    public class StationInformation : IStationInformation
    {
        public StationInformation(StationInfo info)
        {
            this.Id = info.Id;
            this.Name = info.Names.FirstOrDefault();
            this.Location = new GeoCoordinate(
                info.CenterPoint.Latitude,
                info.CenterPoint.Longitude);
        }

        public int Id { get; }
        public string Name { get; }
        public GeoCoordinate Location { get; }
    }
}