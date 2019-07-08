namespace BusStopsDataGrabber
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using BusTracker.Utilities;
    using BusTracker.Utilities.Serializers;
    using Entities;

    public class DataGrabber
    {
        private readonly HttpRequestHandler requestHandler;
        private readonly JsonSerializer jsonSerializer;

        public DataGrabber()
        {
            var httpClient = new HttpClient
            {
                DefaultRequestHeaders = { { "Accept-Encoding", "gzip, deflate, br" } }
            };

            this.requestHandler = new HttpRequestHandler(httpClient);
            this.jsonSerializer = new JsonSerializer();
        }

        public async Task<List<PlaceInformation>> Collect(Settings settings)
        {
            var request = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={settings.Latitude},{settings.Longitude}&radius={settings.Radius}&type=bus_station&key={settings.GoogleApiKey}&language=uk&region=UA";
            var results = new List<PlaceInformation>();
            try
            {
                var response = await this.requestHandler.HandleAsync(request);
                var placesApiQueryResponse = this.jsonSerializer.Deserialize<PlacesApiQueryResponse>(response);
                results.AddRange(placesApiQueryResponse.Results);

                if (string.IsNullOrWhiteSpace(placesApiQueryResponse.NextPageToken))
                {
                    //PlacesApiQueryResponse pageResponse;
                    //do
                    //{
                    //    var pageRequest =
                    //        $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={settings.Latitude},{settings.Longitude}&radius={settings.Radius}&type=bus_station&key={settings.GoogleApiKey}&language=uk&region=UA";
                    //    pageResponse = await this.CollectPage(pageRequest);
                    //    results.AddRange(pageResponse.Results);
                    //} while (string.IsNullOrWhiteSpace(pageResponse.NextPageToken));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }

            return results;
        }

        public async Task<PlacesApiQueryResponse> CollectPage(string request)
        {
            var response = await this.requestHandler.HandleAsync(request);
            var placesApiQueryResponse = this.jsonSerializer.Deserialize<PlacesApiQueryResponse>(response);
            return placesApiQueryResponse;
        }
    }
}