namespace BusTracker.GeoDataProviders.Dozor
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BusTracker.GeoDataProviders.Dozor.Entities;
    using BusTracker.Utilities.Serializers;

    public class DataLoader
    {
        private readonly RequestHandler requestHandler;
        private readonly JsonSerializer jsonSerializer;

        public DataLoader()
        {
            this.requestHandler = new RequestHandler();
            this.jsonSerializer = new JsonSerializer();
        }

        public async Task<WrappedData<RouteInfo>> GetBusLocations(IEnumerable<int> busIds)
        {
            var requestPath = $"/data?t=2&p={string.Join(",", busIds)}";
            return await this.ProcessRequest<WrappedData<RouteInfo>>(requestPath);
        }

        public async Task<WrappedData<GeneralRouteInfo>> GetGeneralData()
        {
            var requestPath = $"/data?t=1";
            return await this.ProcessRequest<WrappedData<GeneralRouteInfo>>(requestPath);
        }

        public async Task<List<TrackerData>> GetFreeData()
        {
            const string requestPath = "http://t.dozor-gps.com.ua/data?t=17";
            return await this.ProcessRequest<List<TrackerData>>(requestPath);
        }

        private async Task<TEntity> ProcessRequest<TEntity>(string requestPath)
            where TEntity: class, new()
        {
            try
            {
                var content = await this.requestHandler.HandleAsync(requestPath);
                return this.jsonSerializer.Deserialize<TEntity>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }
        }
    }
}
