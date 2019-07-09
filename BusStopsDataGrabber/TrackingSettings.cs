namespace BusStopsDataGrabber
{
    public class TrackingSettings
    {

        public double BottomLeftLatitude { get; set; }

        public double BottomLeftLongitude { get; set; }

        public double TopRightLatitude { get; set; }

        public double TopRightLongitude { get; set; }

        public int Steps { get; set; }

        public string GoogleApiKey { get; set; }
    }
}