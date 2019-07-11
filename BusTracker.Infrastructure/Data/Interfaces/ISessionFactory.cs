namespace BusTracker.Infrastructure.Interfaces
{
    public interface ISessionFactory
    {
        IConnection GetSession();
    }
}