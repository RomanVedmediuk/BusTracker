namespace BusTracker.Contracts.Interfaces
{
    using System.Collections.Generic;

    public interface IRouteInformation
    {
        int Id { get; }

        string Name { get; }

        string Description { get; }

        List<IStationInformation> Stations { get; }
    }
}