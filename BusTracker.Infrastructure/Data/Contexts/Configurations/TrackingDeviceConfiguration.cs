namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrackingDeviceConfiguration : EntityConfiguration<TrackingDevice>
    {
        public override void Configure(EntityTypeBuilder<TrackingDevice> builder)
        {
            builder.HasMany(_ => _.TrackingData)
                .WithOne(_ => _.TrackingDevice)
                .HasForeignKey(_ => _.TrackingDeviceId);

            builder.HasOne(_ => _.Vehicle)
                .WithOne(_ => _.TrackingDevice)
                .HasForeignKey<Vehicle>(_ => _.TrackingDeviceId);

            base.Configure(builder);
        }
    }
}