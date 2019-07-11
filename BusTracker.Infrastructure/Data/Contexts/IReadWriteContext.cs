namespace BusTracker.Infrastructure.Data.Contexts
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IReadWriteContext
    {
        DbSet<BusStation> BusStation { get; }

        DbSet<Vehicle> Vehicle { get; }

        DbSet<Route> Route { get; }

        DbSet<RouteStationMapping> RouteStationMapping { get;}

        DbSet<TrackingDevice> TrackingDevice { get; }

        DbSet<TrackingDataLog> TrackingDataLog { get; }

        int SaveChanges();
    }
}