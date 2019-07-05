namespace BusTracker.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BusTracker.Contracts.Interfaces;
    using BusTracker.GeoDataProviders.Dozor;
    using GeoCoordinatePortable;

    public class Core
    {
        private readonly ITrackingInfoProvider provider;
        private List<IRouteInformation> trackedRoutes;

        public Core()
        {
            this.provider = new DozorDataProvider();
        }

        public void Start()
        {
            var routes = this.provider.GetRoutes();
            var favoriteRoutes = new List<string> { "49", "39", "2" };
            this.trackedRoutes = routes.Where(r => favoriteRoutes.Contains(r.Name)).ToList();

        }

        public void Update()
        {
            var ids = this.trackedRoutes.Select(sr => sr.Id).ToList();
            var trackingData = this.provider.GetTrackingInformationByRouteIds(ids);

            foreach (var currentTrack in trackingData)
            {
                var route = this.trackedRoutes.FirstOrDefault(sr => sr.Id == currentTrack.RouteId);
                var latitude = currentTrack.GeoPosition.Latitude;
                var longitude = currentTrack.GeoPosition.Longitude;
                var nearestStation = GetClosestStation(
                    latitude,
                    longitude,
                    route?.Stations);

                Console.WriteLine(
                    $"[{route?.Name,2}] \t [{currentTrack.RegistrationNumber,10}] \t {currentTrack.GeoPosition.Course} \t {currentTrack.GeoPosition.Speed} \t [{nearestStation.Name}]");
            }

            var data = this.provider.GetFreeData().ToList();
            var groupedByImei = data.GroupBy(trackerData => trackerData.Imei);
            var totalCount = groupedByImei.Count();
            var actualCount = data.Count(x => (DateTime.UtcNow - x.TimeStamp) < TimeSpan.FromMinutes(1));
        }

        private static IStationInformation GetClosestStation(double latitude, double longitude, IEnumerable<IStationInformation> trackingData)
        {
            var vehicleLocation = new GeoCoordinate(latitude, longitude);
            var closestStation = trackingData.OrderBy(x => vehicleLocation.GetDistanceTo(x.Location)).FirstOrDefault();

            return closestStation;
        }
    }
}
