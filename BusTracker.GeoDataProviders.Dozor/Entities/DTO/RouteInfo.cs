namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class RouteInfo
    {
        [DataMember(Name = "rId", Order = 0)]
        public int RouteId { get; private set; }

        [DataMember(Name = "dvs", Order = 1)]
        public List<BusInfo> Dvs { get; private set; }
    }
}
