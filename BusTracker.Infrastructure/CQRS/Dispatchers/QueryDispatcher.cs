namespace BusTracker.Infrastructure.CQRS.Dispatchers
{
    using System;
    using BusTracker.Infrastructure.CQRS.Exceptions;
    using BusTracker.Infrastructure.CQRS.Handlers;
    using BusTracker.Infrastructure.CQRS.Queries;

    public class QueryDispatcher<TResult> : IQueryDispatcher<TResult>
    {
        private readonly IQueryHandlerFactory queryHandlerFactory;

        public QueryDispatcher(IQueryHandlerFactory queryHandlerFactory)
        {
            this.queryHandlerFactory = queryHandlerFactory;
        }

        public TResult Execute<TQuery>(TQuery query) where TQuery : IQuery
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = this.queryHandlerFactory.Resolve<IQueryHandler<TQuery>>();

            if (handler == null)
            {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }

            return handler.Execute<TResult>(query);
        }
    }
}