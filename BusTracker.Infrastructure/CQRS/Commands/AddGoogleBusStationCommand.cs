namespace BusTracker.Infrastructure.CQRS.Commands
{
    using GeoAPI.Geometries;
    using NetTopologySuite.Geometries;

    public class AddGoogleBusStationCommand : ICommand
    {
        public AddGoogleBusStationCommand(string placeId, string name, double latitude, double longitude)
        {
            this.GooglePlaceId = placeId;
            this.Name = name;

            this.Location = new Point(latitude, longitude)
            {
                SRID = 4326
            };
        }

        public string GooglePlaceId { get; private set; }

        public string Name { get; private set; }

        public IPoint Location { get; private set; }
    }
}