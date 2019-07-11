namespace BusTracker.Infrastructure.Data.Entities
{
    public class Vehicle : Entity
    {
        public int TrackingDeviceId { get; set; }

        public int RouteId { get; set; }

        public string VehicleBrand { get; set; }

        public byte VehicleQuality { get; set; }

        public bool HasLowLanding { get; set; }

        public bool HasHingeConnection { get; set; }

        public bool HasClimateControl { get; set; }

        public bool HasPaymentDevice { get; set; }

        public TrackingDevice TrackingDevice { get; set; }

        public Route Route { get; set; }
    }
}