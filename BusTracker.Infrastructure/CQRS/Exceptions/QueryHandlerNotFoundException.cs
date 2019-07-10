namespace BusTracker.Infrastructure.CQRS.Exceptions
{
    using System;

    public class QueryHandlerNotFoundException : Exception
    {
        public QueryHandlerNotFoundException(Type exceptionType)
        {
            Console.WriteLine($"Query handler with type {exceptionType} does not exist");
        }
    }
}