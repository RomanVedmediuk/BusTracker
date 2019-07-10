namespace BusTracker.Infrastructure.CQRS.Dispatchers
{
    using System;
    using BusTracker.Infrastructure.CQRS.Commands;
    using BusTracker.Infrastructure.CQRS.Exceptions;
    using BusTracker.Infrastructure.CQRS.Handlers;

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerFactory handlerFactory;

        public CommandDispatcher(ICommandHandlerFactory handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var handler = this.handlerFactory.Resolve<ICommandHandler<TCommand>>();

            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            handler.Execute(command);
        }
    }
}