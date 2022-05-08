namespace RequestPrototype.Models
{
    public class intraDayResponse
    {
        // this model should hold the data that will be passed to a view. Holds the results of the JSON response (after parse of course)
        public string time { get; set; }
        public string open { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string close { get; set; }
        public string volume { get; set; }
    }
}
