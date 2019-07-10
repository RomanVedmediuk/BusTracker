namespace BusTracker.Infrastructure.CQRS.Handlers
{
    public interface ICommandHandlerFactory
    {
        TCommandHandler Resolve<TCommandHandler>();

    }
}