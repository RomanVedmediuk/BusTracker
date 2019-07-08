using System.Collections.Generic;

namespace BusStopsDataGrabber.Entities
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PlacesApiQueryResponse
    {
        [DataMember(Name = "html_attributions", Order = 0)]
        public List<object> Attributions { get; set; }

        [DataMember(Name = "next_page_token", Order = 1)]
        public string NextPageToken { get; set; }

        [DataMember(Name = "results", Order = 2)]
        public List<PlaceInformation> Results { get; set; }

        [DataMember(Name = "status", Order = 3)]
        public string Status { get; set; }
    }
}
