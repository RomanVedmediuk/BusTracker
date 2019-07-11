namespace BusTracker.Infrastructure.Data.Entities
{
    using System.Collections.Generic;

    public class Route : Entity
    {
        public string Name { get; set; }

        public int FirstStationMappingId { get; set; }

        public int LastStationMappingId { get; set; }

        public RouteStationMapping FirstStationRouteStationMapping { get; set; }

        public RouteStationMapping LastStationsRouteStationMapping { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}