namespace BusTracker.Utilities
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class HttpRequestHandler
    {
        private readonly HttpClient client;

        public HttpRequestHandler(HttpClient client)
        {
            this.client = client;
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
                            return await reader.ReadToEndAsync();
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
    }
}
