namespace BusTracker.Infrastructure.CQRS.Exceptions
{
    using System;

    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type exceptionType)
        {
            Console.WriteLine($"Command handler with type {exceptionType} does not exist");
        }
    }
}