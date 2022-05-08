using Newtonsoft.Json;

namespace RequestPrototype.Models
{
    public class intraDayResponse
    {
        // this model should hold the data that will be passed to a view. Holds the results of the JSON response (after parse of course)
        //[JsonProperty("time")]
        public string Time { get; set; }
        //[JsonProperty("open")]
        public string Open { get; set; }
        //[JsonProperty("high")]
        public string High { get; set; }
        //[JsonProperty("low")]
        public string Low { get; set; }
        //[JsonProperty("close")]
        public string Close { get; set; }
        //[JsonProperty("volume")]
        public string Volume { get; set; }
    }
}
