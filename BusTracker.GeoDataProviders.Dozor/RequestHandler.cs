namespace BusTracker.GeoDataProviders.Dozor
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class RequestHandler
    {
        private const string Address = "https://city.dozor.tech";

        private readonly HttpClient client;

        public RequestHandler()
        {
            this.client = CreateClient();
        }

        public async Task<string> HandleAsync(string requestPath)
        {
            try
            {
                using (var httpResponseMessage = await this.client.GetAsync(requestPath))
                {
                    using (var content = httpResponseMessage.Content)
                    {
                        var stream = new GZipStream(await content.ReadAsStreamAsync(), CompressionMode.Decompress);

                        using (var reader = new StreamReader(stream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                var baseException = e.GetBaseException();
                Console.WriteLine(baseException);
                throw;
            }
        }

        private static HttpClient CreateClient()
        {
            var baseUrl = new Uri(Address);

            var collection = new CookieCollection
            {
                new Cookie("gts.web.uuid", Guid.NewGuid().ToString()),
                new Cookie("gts.web.city", "iv-frankivsk"),
                new Cookie("JSESSIONID", $"{Guid.NewGuid():N}".ToUpper()),
                new Cookie("gts.web.google_map.center.lon", "48.92278125079759"),
                new Cookie("gts.web.google_map.center.lat", "24.68902587890625"),
                new Cookie("gts.web.google_map.zoom", "13")
            };

            var cookies = new CookieContainer();
            cookies.Add(baseUrl, collection);

            var clientHandler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = cookies
            };

            return new HttpClient(clientHandler)
            {
                BaseAddress = baseUrl,
                DefaultRequestHeaders = { { "Accept-Encoding", "gzip, deflate, br" } }
            };
        }
    }
}
