namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using BusTracker.Contracts.Interfaces;
    using GeoCoordinatePortable;

    internal class TrackingInformation : ITrackingInformation
    {
        internal TrackingInformation(int routeId, BusInfo info)
        {
            this.Id = info.BusId;
            this.RouteId = routeId;
            this.HasHingeConnection = info.HasHingeConnection;
            this.HasLowLanding = info.HasLowLanding;
            this.RegistrationNumber = info.RegistrationNumber;
            this.GeoPosition = new GeoCoordinate(
                info.Location.Latitude,
                info.Location.Longitude,
                0,
                0,
                0,
                info.Speed,
                info.Azimuth);
        }

        public int RouteId { get;}

        public int Id { get; }

        public GeoCoordinate GeoPosition { get; }

        public string RegistrationNumber { get; }

        public bool? HasLowLanding { get; }

        public bool? HasHingeConnection { get; }
    }
}
