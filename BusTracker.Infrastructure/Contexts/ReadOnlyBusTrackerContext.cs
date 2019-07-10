namespace BusTracker.Infrastructure.Contexts
{
    using Microsoft.EntityFrameworkCore;

    public class ReadOnlyBusTrackerContext : DbContext, IReadOnlyContext
    {
        
    }
}