namespace BusTracker.Infrastructure.Data.Entities
{
    public class RouteStationMapping : Entity
    {
        public int RouteId { get; set; }

        public int StationId { get; set; }

        public int PreviousStationMappingId { get; set; }

        public int NextStationMappingId { get; set; }

        public Route Route { get; set; }

        public BusStation BusStation { get; set; }

        public RouteStationMapping PreviousStationRouteStationMapping { get; set; }

        public RouteStationMapping NextStationRouteStationMapping { get; set; }
    }
}