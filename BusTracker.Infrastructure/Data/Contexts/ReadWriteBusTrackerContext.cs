namespace BusTracker.Infrastructure.Data.Contexts
{
    using BusTracker.Infrastructure.Data.Contexts.Configurations;
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ReadWriteBusTrackerContext : DbContext, IReadWriteContext
    {
        private readonly string connectionString;

        public ReadWriteBusTrackerContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public virtual DbSet<BusStation> BusStation { get; set; }

        public virtual DbSet<Vehicle> Vehicle { get; set; }

        public virtual DbSet<Route> Route { get; set; }

        public virtual DbSet<RouteStationMapping> RouteStationMapping { get; set; }

        public virtual DbSet<TrackingDevice> TrackingDevice { get; set; }

        public virtual DbSet<TrackingDataLog> TrackingDataLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.connectionString,
                x => x.UseNetTopologySuite());
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BusStationsConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new RouteConfiguration());
            builder.ApplyConfiguration(new RouteStationMappingConfiguration());
            builder.ApplyConfiguration(new TrackingDeviceConfiguration());
            builder.ApplyConfiguration(new TrackingDataLogConfiguration());
        }
    }
}