namespace BusTracker.Infrastructure.Data.Entities
{
    using System.Collections.Generic;

    public class TrackingDevice : Entity
    {
        public long Imei { get; set; }

        public Vehicle Vehicle;

        public ICollection<TrackingDataLog> TrackingData;
    }
}