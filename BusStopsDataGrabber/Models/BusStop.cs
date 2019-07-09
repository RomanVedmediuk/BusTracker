namespace BusStopsDataGrabber.Models
{
    using System;
    using NetTopologySuite.Geometries;

    public class BusStop
    {
        public Guid Id { get; set; }

        public string PlaceId { get; set; }

        public string Name { get; set; }

        public Point Location { get; set; }
    }
}
