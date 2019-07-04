namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class GeneralRouteInfo
    {
        [DataMember(Name = "id", Order = 0)]
        public int Id { get; private set; }

        [DataMember(Name = "sNm", Order = 6)]
        public string Name { get; private set; }

        [DataMember(Name = "nm", Order = 3)]
        public List<string> Descriptions { get; private set; }

        [DataMember(Name = "oLC", Order = 4)]
        public string Color { get; private set; }

        [DataMember(Name = "inf", Order = 1)]
        [Obsolete("Unknown parameter")]
        public string Inf { get; private set; }

        [DataMember(Name = "lns", Order = 2)]
        [Obsolete("The save as `ctr` parameter in in `zns` list")]
        public List<object> MapPoints { get; private set; }

        [DataMember(Name = "prc", Order = 5)]
        [Obsolete("Price is obsolete and not supported by provider")]
        public int Price { get; private set; }

        [DataMember(Name = "zns", Order = 7)]
        public List<StationInfo> Stations { get; private set; }
    }
}
