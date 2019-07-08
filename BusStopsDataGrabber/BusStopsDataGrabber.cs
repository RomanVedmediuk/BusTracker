namespace BusStopsDataGrabber
{
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using System;

    public static class BusStopsDataGrabber
    {
        public static void Main(string[] args)
        {
            var settings = new Settings();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", false, true)
                .Build();

            config.Bind(settings);
            var grabber = new DataGrabber();
            var dataTask = grabber.Collect(settings);


            var data = dataTask.Result;

            Console.ReadKey();
            Console.ReadLine();
        }
    }
}
