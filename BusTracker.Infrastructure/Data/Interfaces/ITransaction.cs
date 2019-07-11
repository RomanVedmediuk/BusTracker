namespace BusTracker.Infrastructure.Interfaces
{
    using System;

    public interface ITransaction : IDisposable
    {
        void Commit();

        void Rollback();
    }
}