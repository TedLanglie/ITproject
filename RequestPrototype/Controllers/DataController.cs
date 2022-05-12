using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RequestPrototype.Models;
using System.Net;

namespace RequestPrototype.Controllers
{
    public class DataController : Controller
    {
        public IActionResult StockDataDisplay(UserInput input)
        {
            if (ModelState.IsValid && input.Ticker != null)
                return View(GetJsonData(input.Ticker));
            return View();
        }

        public Rootobject GetJsonData(string symbol, string function = "TIME_SERIES_INTRADAY", string interval = "5min")
        {
            string QUERY_URL = $"https://www.alphavantage.co/query?function={function}&symbol={symbol}&interval={interval}&apikey=3HAONZ71TFYS0307";
            Uri queryUri = new Uri(QUERY_URL);
            using (WebClient client = new())
            {
                string jsonString = client.DownloadString(queryUri);
                Rootobject? dataJson = JsonConvert.DeserializeObject<Rootobject>(jsonString);
                return dataJson ?? new Rootobject(); // if null, returns new Rootobject with null member variables
            }
        }
    }
}
