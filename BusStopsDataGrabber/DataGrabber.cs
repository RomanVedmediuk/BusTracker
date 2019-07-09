namespace BusStopsDataGrabber
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using BusTracker.Utilities;
    using BusTracker.Utilities.Serializers;
    using Entities;

    public class DataGrabber
    {
        private readonly HttpRequestHandler requestHandler;
        private readonly JsonSerializer jsonSerializer;
        private readonly string apiKey;

        public DataGrabber(string apiKey)
        {
            var httpClient = new HttpClient
            {
                DefaultRequestHeaders = { { "Accept-Encoding", "gzip, deflate, br" } }
            };

            this.apiKey = apiKey;
            this.requestHandler = new HttpRequestHandler(httpClient);
            this.jsonSerializer = new JsonSerializer();
        }

        public List<PlaceInformation> Collect(double lat, double lng, int rad)
        {
            var request = $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={lat},{lng}&radius={rad}&type=bus_station&key={this.apiKey}&language=uk&region=UA";
            var results = new List<PlaceInformation>();
            try
            {
                var response = this.requestHandler.HandleAsync(request).Result;
                var placesApiQueryResponse = this.jsonSerializer.Deserialize<PlacesApiQueryResponse>(response);
                results.AddRange(placesApiQueryResponse.Results);
                var nextPageToken = placesApiQueryResponse.NextPageToken;
                Console.WriteLine($"Status: {placesApiQueryResponse.Status}");
                Console.WriteLine($"Request: {request}");
                Console.WriteLine($"Token: {nextPageToken}");
                Console.WriteLine($"Loaded: {results.Count}");

                while (!string.IsNullOrWhiteSpace(nextPageToken))
                {
                    Thread.Sleep(2000);
                    var pageRequest =
                        $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?pagetoken={nextPageToken}&key={this.apiKey}&language=uk&region=UA";

                    var pageResponse = this.requestHandler.HandleAsync(pageRequest).Result;
                    var pagePlacesApiQueryResponse = this.jsonSerializer.Deserialize<PlacesApiQueryResponse>(pageResponse);
                    results.AddRange(pagePlacesApiQueryResponse.Results);
                    nextPageToken = pagePlacesApiQueryResponse.NextPageToken;

                    Console.WriteLine($"Page Status: {pagePlacesApiQueryResponse.Status}");
                    Console.WriteLine($"Page Request: {pageRequest}");
                    Console.WriteLine($"Token: {nextPageToken}");
                    Console.WriteLine($"Loaded: {results.Count}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
                throw;
            }

            return results;
        }
    }
}