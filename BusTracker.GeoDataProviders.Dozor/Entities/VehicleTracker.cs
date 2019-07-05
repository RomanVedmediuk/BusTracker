namespace BusTracker.GeoDataProviders.Dozor.Entities
{
    using System;
    using BusTracker.Contracts.Interfaces;

    public class VehicleTracker : IVehicleTracker
    {
        public VehicleTracker(TrackerData trackerData)
        {
            this.Imei = trackerData.Imei;
            this.Latitude = trackerData.Latitude;
            this.Longitude = trackerData.Longitude;
            this.Satellite = trackerData.Satellite;
            this.Speed = trackerData.Speed;

            if (!string.IsNullOrWhiteSpace(trackerData.Time))
            {
                this.TimeStamp = DateTime.Parse(trackerData.Time);
            }
        }

        public DateTime? TimeStamp { get;}

        public int Speed { get;}

        public int Satellite { get;}

        public double Longitude { get;}

        public double Latitude { get;}

        public string Imei { get;}
    }
}