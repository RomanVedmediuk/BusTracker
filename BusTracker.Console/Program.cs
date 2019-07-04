namespace BusTracker.Console
{
    using BusTracker.GeoDataProviders.Dozor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusTracker.Contracts.Interfaces;
    using GeoCoordinatePortable;

    class Program
    {
        static void Main(string[] args)
        {
            var provider = new DozorDataProvider();
            var routes = provider.GetRoutes();
            var favoriteRoutes = new List<string> {"49", "2"};
            var selectedRoutes = routes.Where(r => favoriteRoutes.Contains(r.Name)).ToList();
            var ids = selectedRoutes.Select(sr => sr.Id);

            var trackingData = provider.GetTrackingInformationByRouteIds(ids);

            foreach (var currentTrack in trackingData)
            {
                var route = selectedRoutes.FirstOrDefault(sr => sr.Id == currentTrack.RouteId);
                var latitude = currentTrack.GeoPosition.Latitude;
                var longitude = currentTrack.GeoPosition.Longitude;
                var nearestStation = GetClosestStation(
                    latitude,
                    longitude,
                    route?.Stations);

                Console.WriteLine($"[{route?.Name,2}] \t [{currentTrack.RegistrationNumber,10}] \t [{nearestStation.Name}]");

            }
            Console.ReadLine();
            Console.ReadKey();
        }

        private static IStationInformation GetClosestStation(double latitude, double longitude, IEnumerable<IStationInformation> trackingData)
        {
            var vehicleLocation = new GeoCoordinate(latitude, longitude);
            var closestStation = trackingData.OrderBy(x => vehicleLocation.GetDistanceTo(x.Location)).FirstOrDefault();

            return closestStation;
        }
    }
}
