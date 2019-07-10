namespace BusTracker.Infrastructure.CQRS.Handlers
{
    using BusTracker.Infrastructure.CQRS.Commands;

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}