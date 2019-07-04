namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BusInfo
    {
        [DataMember(Name = "id", Order = 3)]
        public int BusId { get; private set; }

        [DataMember(Name = "loc", Order = 4)]
        public Location Location { get; private set; }

        [DataMember(Name = "azi", Order = 0)]
        public int Azimuth { get; private set; }

        [DataMember(Name = "spd", Order = 6)]
        public int Speed { get; private set; }

        [DataMember(Name = "gNb", Order = 2)]
        public string RegistrationNumber { get; private set; }

        [DataMember(Name = "dis", Order = 1)]
        public bool HasLowLanding { get; private set; }

        [DataMember(Name = "rad", Order = 5)]
        public bool HasHingeConnection { get; private set; }
    }
}
