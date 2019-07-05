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
            
            this.Stations = route.Stations
                .Select(x => new StationInformation(x))
                .Cast<IStationInformation>()
                .ToList();
        }

        public int Id { get; }

        public string Name { get; }

        public string Description { get; }

        public List<IStationInformation> Stations { get; }
    }
}
