namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class WrappedData<T>
    {
        [DataMember(Name = "hash", Order = 0)]
        public long Hash { get; private set; }

        [DataMember(Name = "data", Order = 1)]
        public List<T> Data { get; private set; }
    }
}
