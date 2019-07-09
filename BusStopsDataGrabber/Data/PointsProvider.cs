namespace BusStopsDataGrabber.Data
{
    using System;
    using System.Collections.Generic;
    using GeoAPI.Geometries;

    public static class PointsProvider
    {
        public static List<Coordinate> SelectPoints(Coordinate bottomLeft, Coordinate topRight, int steps)
        {
            var points = new List<Coordinate>();
            var isNegativeDeltaX = topRight.X - bottomLeft.X < 0;
            var deltaX = Math.Abs(topRight.X - bottomLeft.X) / steps;
            var isNegativeDeltaY = topRight.Y - bottomLeft.Y < 0;
            var deltaY = Math.Abs(topRight.Y - bottomLeft.Y) / steps;

            var radius = GetDistanceFromLatLonInKm(bottomLeft.X, bottomLeft.Y, topRight.X, topRight.Y) / steps / 2;
            for (var x=0 ; x <= steps; x++)
            for (var y = 0; y <= steps; y++)
            {
                var pointX = bottomLeft.X + (isNegativeDeltaX ? -1 : 1) * x * deltaX;
                var pointY = bottomLeft.Y + (isNegativeDeltaY ? -1 : 1) * y * deltaY;
                points.Add(new Coordinate(pointX, pointY, radius));
            }

            return points;
        }

        private static double GetDistanceFromLatLonInKm(double lat1, double lng1, double lat2, double lng2)
        {
            const int earthRadius = 6371; // Radius of the earth in km
            var dLat = DegreeToRadians(lat2 - lat1);  // deg2rad below
            var dLon = DegreeToRadians(lng2 - lng1);
            var a =
                    Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(DegreeToRadians(lat1)) * Math.Cos(DegreeToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
                ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = earthRadius * c; // Distance in km
            return d;
        }

        private static double DegreeToRadians(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}