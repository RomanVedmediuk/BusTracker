namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using BusTracker.Contracts.Interfaces;

    internal class TrackingInformation : ITrackingInformation
    {
        internal TrackingInformation(int routeId, BusInfo info)
        {
            this.Id = info.BusId;
            this.RouteId = routeId;
            this.HasHingeConnection = info.HasHingeConnection;
            this.HasLowLanding = info.HasLowLanding;
            this.RegistrationNumber = info.RegistrationNumber;
            this.GeoPosition = new GeoPosition(info);
        }

        public int RouteId { get;}

        public int Id { get; }

        public IGeoPosition GeoPosition { get; }

        public string RegistrationNumber { get; }

        public bool? HasLowLanding { get; }

        public bool? HasHingeConnection { get; }
    }
}
