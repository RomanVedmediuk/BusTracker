namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class StationInfo
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; private set; }

        [DataMember(Name = "nm", Order = 1)]
        public List<string> Names { get; private set; }

        [DataMember(Name = "ctr", Order = 2)]
        public Location CenterPoint { get; private set; }

        [DataMember(Name = "pt", Order = 3)]
        public Location StationPoint { get; private set; }
    }
}