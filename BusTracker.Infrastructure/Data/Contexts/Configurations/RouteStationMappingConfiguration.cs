namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RouteStationMappingConfiguration : EntityConfiguration<RouteStationMapping>
    {
        public override void Configure(EntityTypeBuilder<RouteStationMapping> builder)
        {
            builder.HasKey(sc => new { sc.RouteId, sc.StationId, sc.PreviousStationMappingId, sc.NextStationMappingId});

            builder.HasOne(_ => _.Route)
                .WithOne(_ => _.FirstStationRouteStationMapping)
                .HasForeignKey<Route>(_ => _.FirstStationMappingId);

            builder.HasOne(_ => _.Route)
                .WithOne(_ => _.LastStationsRouteStationMapping)
                .HasForeignKey<Route>(_ => _.LastStationMappingId);

            builder.HasOne(_ => _.BusStation)
                .WithMany(_ => _.RouteStationMappings)
                .HasForeignKey(_ => _.StationId);

            builder.HasOne(_ => _.PreviousStationRouteStationMapping)
                .WithOne(_ => _.NextStationRouteStationMapping)
                .HasForeignKey<RouteStationMapping>(_ => _.PreviousStationRouteStationMapping);

            builder.HasOne(_ => _.NextStationRouteStationMapping)
                .WithOne(_ => _.PreviousStationRouteStationMapping)
                .HasForeignKey<RouteStationMapping>(_ => _.NextStationMappingId);

            base.Configure(builder);
        }
    }
}