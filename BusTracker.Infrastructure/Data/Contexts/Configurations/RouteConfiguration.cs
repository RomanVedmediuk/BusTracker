namespace BusTracker.Infrastructure.Data.Contexts.Configurations
{
    using BusTracker.Infrastructure.Data.Entities;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RouteConfiguration : EntityConfiguration<Route>
    {
        public override void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasOne(_ => _.FirstStationRouteStationMapping)
                .WithOne(_ => _.Route)
                .HasForeignKey<RouteStationMapping>(_ => _.RouteId);
           
            builder.HasOne(_ => _.LastStationsRouteStationMapping)
                .WithOne(_ => _.Route)
                .HasForeignKey<RouteStationMapping>(_ => _.RouteId);

            builder.HasMany(_ => _.Vehicles)
                .WithOne(_ => _.Route)
                .HasForeignKey(_ => _.Id);

            base.Configure(builder);
        }
    }
}