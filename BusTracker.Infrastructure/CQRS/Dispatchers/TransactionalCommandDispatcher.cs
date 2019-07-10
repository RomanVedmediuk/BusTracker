namespace BusTracker.Infrastructure.CQRS.Dispatchers
{
    using System;
    using BusTracker.Infrastructure.CQRS.Commands;
    using BusTracker.Infrastructure.Interfaces;

    public class TransactionalCommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher nextCommandDispatcher;
        private readonly ISessionFactory sessionFactory;

        public TransactionalCommandDispatcher(
            ICommandDispatcher nextCommandDispatcher,
            ISessionFactory sessionFactory)
        {
            this.nextCommandDispatcher = nextCommandDispatcher;
            this.sessionFactory = sessionFactory;
        }

        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (var session = this.sessionFactory.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        this.nextCommandDispatcher.Execute(command);
                        transaction.Commit();
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
