namespace RequestPrototype.Models
{
    public class Rootobject
    {
        public MetaData MetaData { get; set; }
        public TimeSeries TimeSeries { get; set; }
    }

    public partial class MetaData
    {
        public string Information { get; set; }
        public string Symbol { get; set; }
        public string LastRefreshed { get; set; }
        public string Interval { get; set; }
        public string OutputSize { get; set; }
        public string TimeZone { get; set; }
    }

    public class TimeSeries
    {
        public StockData[] StockData { get; set; }
    }

    public class StockData
    {
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
    }
}



