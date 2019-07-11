namespace BusTracker.Infrastructure.Data.Entities
{
    using System.Collections.Generic;
    using GeoAPI.Geometries;

    public class BusStation : Entity
    {
        public string StationInternalId { get; set; }

        public string Name { get; set; }

        public IPoint Location { get; set; }

        public ICollection<RouteStationMapping> RouteStationMappings { get; set; }
    }
}