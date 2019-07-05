namespace BusTracker.Contracts.Interfaces
{
    using System.Collections.Generic;

    public interface ITrackingInfoProvider
    {
        IEnumerable<ITrackingInformation> GetTrackingInformationByRouteIds(IEnumerable<int> routeIds);

        IEnumerable<IRouteInformation> GetRoutes();

        IEnumerable<IVehicleTracker> GetFreeData();
    }
}
