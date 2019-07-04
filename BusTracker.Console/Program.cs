namespace BusTracker.Console
{
    using BusTracker.GeoDataProviders.Dozor;
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var provider = new DozorDataProvider();
            var routes = provider.GetRoutes();

            var selectedRoutes = routes.Where(x => x.Name).
            Console.ReadLine();
            Console.ReadKey();
        }
    }
}
