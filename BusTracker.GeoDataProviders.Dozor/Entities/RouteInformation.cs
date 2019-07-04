namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System.Collections.Generic;
    using System.Linq;
    using BusTracker.Contracts.Interfaces;

    public class RouteInformation : IRouteInformation
    {
        public RouteInformation(GeneralRouteInfo route)
        {
            this.Id = route.Id;
            this.Name = route.Name;
            this.Description = route.Descriptions.FirstOrDefault();
            this.MapPoints = route.MapPoints;
            this.Stations = route.Stations;
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public List<object> MapPoints { get; }

        public List<object> Stations { get; }
    }
}
