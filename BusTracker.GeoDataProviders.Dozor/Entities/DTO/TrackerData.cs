namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TrackerData
    {
        [DataMember(Name = "imei", Order = 0)]
        public string Imei { get; private set; }

        [DataMember(Name = "time", Order = 1)]
        public string Time { get; private set; }

        [DataMember(Name = "lng", Order = 2)]
        public double Longitude { get; private set; }

        [DataMember(Name = "lat", Order = 3)]
        public double Latitude { get; private set; }

        [DataMember(Name = "sat", Order = 4)]
        public int Satellite { get; private set; }

        [DataMember(Name = "spd", Order = 5)]
        public int Speed { get; private set; }
    }
}