using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Map
{
    public class AddressComponent
    {

        [JsonProperty("long_name")]
        public string LongName { get; set; }

        [JsonProperty("short_name")]
        public string ShortName { get; set; }

        [JsonProperty("types")]
        public IList<string> Types { get; set; }
    }

    public class Location
    {

        [JsonProperty("lat")]
        public double lat { get; set; }

        [JsonProperty("lng")]
        public double lng { get; set; }
    }

    public class Northeast
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Southwest
    {

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lng")]
        public double Lng { get; set; }
    }

    public class Viewport
    {

        [JsonProperty("northeast")]
        public Northeast Northeast { get; set; }

        [JsonProperty("southwest")]
        public Southwest Nouthwest { get; set; }
    }

    public class Geometry
    {

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("location_type")]
        public string location_type { get; set; }

        [JsonProperty("viewport")]
        public Viewport viewport { get; set; }
    }

    public class Result
    {

        [JsonProperty("address_components")]
        public IList<AddressComponent> address_components { get; set; }

        [JsonProperty("formatted_address")]
        public string formatted_address { get; set; }

        [JsonProperty("geometry")]
        public Geometry geometry { get; set; }

        [JsonProperty("partial_match")]
        public bool partial_match { get; set; }

        [JsonProperty("place_id")]
        public string place_id { get; set; }

        [JsonProperty("types")]
        public IList<string> types { get; set; }
    }

    public class GeoJsonResult
    {

        [JsonProperty("results")]
        public IList<Result> results { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }
    }
}
