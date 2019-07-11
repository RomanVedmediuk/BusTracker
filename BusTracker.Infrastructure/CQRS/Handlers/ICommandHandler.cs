namespace BusTracker.Infrastructure.CQRS.Handlers
{
    using System.Threading.Tasks;
    using BusTracker.Infrastructure.CQRS.Commands;

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}