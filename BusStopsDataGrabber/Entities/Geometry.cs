namespace BusStopsDataGrabber.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Geometry
    {
        [DataMember(Name = "location", Order = 0)]
        public Location Location { get; set; }

        [DataMember(Name = "viewport", Order = 1)]
        public object ViewPort { get; set; }
    }
}