namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VehicleConfiguration : EntityConfiguration<Vehicle>
    {
        public override void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(_ => _.TrackingDevice)
                .WithOne(_ => _.Vehicle)
                .HasForeignKey<TrackingDevice>(_ => _.Id);

            builder.HasOne(_ => _.Route)
                .WithMany(_ => _.Vehicles)
                .HasForeignKey(_ => _.RouteId);

            base.Configure(builder);
        }
    }
}