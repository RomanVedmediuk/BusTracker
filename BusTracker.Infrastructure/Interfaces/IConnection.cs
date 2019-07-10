namespace BusTracker.Infrastructure.Interfaces
{
    using System;

    public interface IConnection : IDisposable
    {
        ITransaction BeginTransaction();
    }
}