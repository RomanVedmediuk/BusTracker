namespace BusTracker.GeoDataProviders.Dozor
{
    using System.Collections.Generic;
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

        /// <summary>
        /// Gets the tracking information by route ids.
        /// </summary>
        /// <param name="routeIds">The route ids.</param>
        /// <returns>IEnumerable&lt;ITrackingInformation&gt;.</returns>
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
    }
}
