namespace BusTracker.GeoDataProviders.Dozor.Converters
{
    using System;
    using System.Collections.Generic;
    using BusTracker.Contracts.Interfaces;
    using BusTracker.GeoDataProviders.Dozor.Entities;

    public static class RouteConverter
    {
        public static IEnumerable<ITrackingInformation> GetTrackingInformation(List<RouteInfo> routes)
        {
            foreach (var route in routes)
            {
                foreach (var bus in route.Dvs)
                {
                    yield return new TrackingInformation(route.RouteId, bus);
                }
            }
        }

        public static IEnumerable<IRouteInformation> GetRouteInformation(IEnumerable<GeneralRouteInfo> routes)
        {
            foreach (var route in routes)
            {
                yield return new RouteInformation(route);
            }
        }
    }
}