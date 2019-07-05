namespace BusTracker.GeoDataProviders.Dozor
{
    using System.Collections.Generic;
    using System.Linq;
    using BusTracker.Contracts.Interfaces;
    using BusTracker.GeoDataProviders.Dozor.Converters;
    using BusTracker.GeoDataProviders.Dozor.Entities;
    using BusTracker.Utilities.Extensions;

    public class DozorDataProvider : ITrackingInfoProvider
    {
        private readonly DataLoader dataLoader;

        public DozorDataProvider()
        {
            this.dataLoader = new DataLoader();
        }

        public IEnumerable<IRouteInformation> GetRoutes()
        {
            var wrappedData = this.dataLoader.GetGeneralData().Result;
            return RouteConverter.GetRouteInformation(wrappedData.Data);
        }

        public IEnumerable<ITrackingInformation> GetTrackingInformationByRouteIds(IEnumerable<int> routeIds)
        {
            var routes = new List<RouteInfo>();
            foreach (var batch in routeIds.Batch(5))
            {
                var wrappedData = this.dataLoader.GetBusLocations(batch).Result;
                routes.AddRange(wrappedData.Data);
            }

            return RouteConverter.GetTrackingInformation(routes);
        }
        public IEnumerable<IVehicleTracker> GetFreeData()
        {
            var data = this.dataLoader.GetFreeData().Result;
            return data.Select(t => new VehicleTracker(t));
        }
    }
}
