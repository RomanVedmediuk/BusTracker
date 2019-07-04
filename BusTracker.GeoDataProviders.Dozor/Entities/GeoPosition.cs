namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using BusTracker.Contracts.Interfaces;

    internal class GeoPosition : IGeoPosition
    {
        internal GeoPosition(BusInfo info)
        {
            this.Latitude = info.Location.Latitude;
            this.Longitude = info.Location.Longitude;
            this.Azimuth = info.Azimuth;
            this.Speed = info.Speed;
        }

        public double? Latitude { get; }

        public double? Longitude { get; }

        public int? Azimuth { get; }

        public int Speed { get; }
    }
}
