namespace BusStopsDataGrabber.Models
{
    using GeoAPI.Geometries;

    public class BusStop
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PlaceId { get; set; }

        public IPoint Geometry { get; set; }
    }
}
