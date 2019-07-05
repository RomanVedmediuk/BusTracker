namespace BusTracker.Console
{
    using BusTracker.GeoDataProviders.Dozor;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using BusTracker.Contracts.Interfaces;
    using GeoCoordinatePortable;

    class Program
    {
        static void Main(string[] args)
        {
            ITrackingInfoProvider provider = new DozorDataProvider();
            var routes = provider.GetRoutes();
            var favoriteRoutes = new List<string> {"49", "39", "2"};
            var selectedRoutes = routes.Where(r => favoriteRoutes.Contains(r.Name)).ToList();
            var ids = selectedRoutes.Select(sr => sr.Id).ToList();

            RunUntilEscape(() =>
            {
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

                    Console.WriteLine(
                        $"[{route?.Name,2}] \t [{currentTrack.RegistrationNumber,10}] \t {currentTrack.GeoPosition.Course} \t {currentTrack.GeoPosition.Speed} \t [{nearestStation.Name}]");
                }
            }, 5000);

            Console.ReadLine();
            Console.ReadKey();
        }

        private static IStationInformation GetClosestStation(double latitude, double longitude, IEnumerable<IStationInformation> trackingData)
        {
            var vehicleLocation = new GeoCoordinate(latitude, longitude);
            var closestStation = trackingData.OrderBy(x => vehicleLocation.GetDistanceTo(x.Location)).FirstOrDefault();

            return closestStation;
        }

        private static void RunUntilEscape(Action action, int threshold)
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    action?.Invoke();
                    Thread.Sleep(threshold);
                    Console.Clear();
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
