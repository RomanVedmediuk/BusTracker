namespace BusStopsDataGrabber.Comparers
{
    using System.Collections.Generic;
    using Models;

    public class PlaceIdEqualityComparer : IEqualityComparer<BusStop>
    {
        public bool Equals(BusStop x, BusStop y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }

            if (ReferenceEquals(x, null))
            {
                return false;
            }

            if (ReferenceEquals(y, null))
            {
                return false;
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return string.Equals(x.PlaceId, y.PlaceId);
        }

        public int GetHashCode(BusStop obj)
        {
            return obj.PlaceId.GetHashCode();
        }
    }
}