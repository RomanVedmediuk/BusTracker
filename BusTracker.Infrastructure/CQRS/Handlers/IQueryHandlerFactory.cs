namespace BusTracker.Infrastructure.CQRS.Handlers
{
    public interface IQueryHandlerFactory
    {
        TQueryHandler Resolve<TQueryHandler>();

    }
}