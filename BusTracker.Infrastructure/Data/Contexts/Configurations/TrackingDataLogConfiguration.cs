namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TrackingDataLogConfiguration : LogConfiguration<TrackingDataLog>
    {
        public override void Configure(EntityTypeBuilder<TrackingDataLog> builder)
        {
            builder.HasOne(_ => _.TrackingDevice)
                .WithMany(_ => _.TrackingData)
                .HasForeignKey(_ => _.TrackingDeviceId);

            base.Configure(builder);
        }
    }
}