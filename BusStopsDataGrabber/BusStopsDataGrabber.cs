namespace BusStopsDataGrabber
{
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GeoAPI.Geometries;
    using Comparers;
    using Context;
    using Data;
    using Entities;
    using Models;
    using NetTopologySuite.Geometries;


    public static class BusStopsDataGrabber
    {
        public static void Main(string[] args)
        {
            var trackingSettings = new TrackingSettings();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", false, true)
                .AddJsonFile("settings.Development.json", optional: true)
                .Build();

            config.GetSection("Tracking").Bind(trackingSettings);
            var grabber = new DataGrabber(trackingSettings.GoogleApiKey);

            var bottomLeftCorner = new Coordinate(48.860606, 24.595572);
            var topRightCorner = new Coordinate(48.985076, 24.793446);
            var steps = trackingSettings.Steps;
            var points = PointsProvider.SelectPoints(new Coordinate(48.860606, 24.595572), new Coordinate(48.985076, 24.793446), 20);

            var places = new List<PlaceInformation>();
            foreach (var point in points)
            {
                Console.WriteLine($"lat: {point.X,10}, lng: {point.Y,10}, rad:{point.Z,10}");
                var collectedData = grabber.Collect(point.X, point.Y, (int)(point.Z * 1000));
                if (collectedData.Count == 60)
                {
                    Console.WriteLine("********* To many data exist for this point *********");
                }

                places.AddRange(collectedData);
            }

            Console.WriteLine($"*Total point loaded: {places.Count}**");
            var busStops = places.ConvertAll(PlaceInformationToBusStop).Distinct(new PlaceIdEqualityComparer()).ToList();
            Console.WriteLine($"*Total point without duplicates: {busStops.Count}**");

            var context = new BusStopContext(config.GetConnectionString("DefaultConnection"));
            context.AddRange(busStops);
            context.SaveChanges();
            Console.WriteLine($"Done!");
        }

        private static BusStop PlaceInformationToBusStop(PlaceInformation place)
        {
            return new BusStop
            {
                PlaceId = place.PlaceId,
                Name = place.Name,
                Location = new Point(place.Geometry.Location.Latitude, place.Geometry.Location.Longitude)
                {
                    SRID = 4326
                }
            };
        }
    }
}
