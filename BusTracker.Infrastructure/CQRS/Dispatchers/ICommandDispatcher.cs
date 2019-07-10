namespace BusTracker.Infrastructure.CQRS.Dispatchers
{
    using BusTracker.Infrastructure.CQRS.Commands;

    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}