namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BusStationsConfiguration : EntityConfiguration<BusStation>
    {
        public override void Configure(EntityTypeBuilder<BusStation> builder)
        {
            builder.HasMany(_ => _.RouteStationMappings)
                .WithOne(_ => _.BusStation)
                .HasForeignKey(_ => _.StationId);

            base.Configure(builder);
        }
    }
}