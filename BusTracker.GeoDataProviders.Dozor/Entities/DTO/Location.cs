namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Location
    {
        [DataMember(Name = "lat", Order = 0)]
        public double Latitude { get; private set; }

        [DataMember(Name = "lng", Order = 1)]
        public double Longitude { get; private set; }
    }
}
