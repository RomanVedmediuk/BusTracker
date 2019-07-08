namespace BusStopsDataGrabber.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Location
    {
        [DataMember(Name = "lat", Order = 0)]
        public double Latitude { get; set; }
        [DataMember(Name = "lng", Order = 0)]
        public double Longitude { get; set; }
    }
}