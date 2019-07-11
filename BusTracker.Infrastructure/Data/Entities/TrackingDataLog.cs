namespace BusTracker.Infrastructure.Data.Entities
{
    using System;
    using GeoAPI.Geometries;

    public class TrackingDataLog : Log
    {
        public int TrackingDeviceId { get; set; }

        public DateTime Time { get; set; }

        public IPoint Location { get; set; }

        public byte Speed { get; set; }

        public TrackingDevice TrackingDevice { get; set; }
    }
}