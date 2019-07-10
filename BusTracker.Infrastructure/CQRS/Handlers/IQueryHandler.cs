namespace BusTracker.Infrastructure.CQRS.Handlers
{
    using BusTracker.Infrastructure.CQRS.Queries;

    public interface IQueryHandler<in TQuery> where TQuery : IQuery
    {
        TResult Execute<TResult>(TQuery query);
    }
}