namespace BusTracker.Contracts.Interfaces
{
    using System;

    public interface IVehicleTracker
    {
        DateTime? TimeStamp { get; }

        int Speed { get; }

        int Satellite { get; }

        double Longitude { get; }

        double Latitude { get; }

        string Imei { get; }
    }
}