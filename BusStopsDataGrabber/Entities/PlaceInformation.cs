namespace BusStopsDataGrabber.Entities
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PlaceInformation
    {
        [DataMember(Name = "geometry", Order = 0)]
        public Geometry Geometry { get; set; }

        [DataMember(Name = "icon", Order = 1, IsRequired = false)]
        public string Icon { get; set; }

        [DataMember(Name = "id", Order = 2, IsRequired = false)]
        public string Id { get; set; }

        [DataMember(Name = "name", Order = 3, IsRequired = false)]
        public string Name { get; set; }

        [DataMember(Name = "photos", Order = 4, IsRequired = false)]
        public List<object> Photos { get; set; }

        [DataMember(Name = "place_id", Order = 5, IsRequired = false)]
        public string PlaceId { get; set; }

        [DataMember(Name = "plus_code", Order = 6, IsRequired = false)]
        public object PlusCode { get; set; }

        [DataMember(Name = "rating", Order = 7, IsRequired = false)]
        public double Rating { get; set; }

        [DataMember(Name = "reference", Order = 8, IsRequired = false)]
        public string Reference { get; set; }

        [DataMember(Name = "scope", Order = 9, IsRequired = false)]
        public string Scope { get; set; }

        [DataMember(Name = "types", Order = 10, IsRequired = false)]
        public List<string> Types { get; set; }

        [DataMember(Name = "user_ratings_total", Order = 11, IsRequired = false)]
        public int UserRatingTotal { get; set; }

        [DataMember(Name = "vicinity", Order = 12, IsRequired = false)]
        public string Vicinity { get; set; }
    }
}