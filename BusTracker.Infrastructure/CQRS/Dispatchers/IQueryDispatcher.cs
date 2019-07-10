namespace BusTracker.Infrastructure.CQRS.Dispatchers
{
    using BusTracker.Infrastructure.CQRS.Queries;

    public interface IQueryDispatcher<out TResult>
    {
        TResult Execute<TQuery>(TQuery query)
            where TQuery : IQuery;
    }
}