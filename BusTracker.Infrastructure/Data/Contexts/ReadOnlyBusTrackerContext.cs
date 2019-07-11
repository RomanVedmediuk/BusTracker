namespace BusTracker.Infrastructure.Data.Contexts
{
    using Microsoft.EntityFrameworkCore;

    public class ReadOnlyBusTrackerContext : DbContext, IReadOnlyContext
    {
        
    }
}