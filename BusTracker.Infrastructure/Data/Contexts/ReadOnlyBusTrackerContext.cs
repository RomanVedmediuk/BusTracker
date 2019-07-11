namespace BusTracker.Infrastructure.Data.Contexts
{
    using Microsoft.EntityFrameworkCore;

    public sealed class ReadOnlyBusTrackerContext : ReadWriteBusTrackerContext, IReadOnlyContext
    {
        public ReadOnlyBusTrackerContext(string connectionString) : base(connectionString)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}