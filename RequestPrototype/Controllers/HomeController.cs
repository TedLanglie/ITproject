using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using RequestPrototype.Models;
using Newtonsoft.Json;

namespace RequestPrototype.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string symbol, string function = "TIME_SERIES_INTRADAY", string interval = "5min") //TODO: Rename this maybe?
        {
            // the query string. Symbol should become variables that are user inputed. (maybe function too but probably not)
            string QUERY_URL = $"https://www.alphavantage.co/query?function={function}&symbol={symbol}&interval={interval}&apikey=3HAONZ71TFYS0307";
            Uri queryUri = new Uri(QUERY_URL);
            using (WebClient client = new WebClient())
            {
                // json_data is the result of querying the data
                string jsonString = client.DownloadString(queryUri);
                Console.WriteLine(QUERY_URL);
                Console.WriteLine(jsonString);

                /* DATA STRUCTURE OF ROOTOBJECT
                 Rootobject { 
                    MetaData {
                        ...
                    }, 
                    Time Series = Dictionary<string, StockData>         String is TimeStamp | StockData has open, high, low, close, volume properties
                }*/

                Rootobject dataJson = JsonConvert.DeserializeObject<Rootobject>(jsonString); 

                return GoToData(dataJson);
            }

        }

        public ActionResult SearchTicker(UserInput input) 
        {
            if (ModelState.IsValid && input.Ticker != null)
            {
                Index(input.Ticker);
            }

            return View("Index", input);
        }

        public IActionResult GoToData(Rootobject data) 
        {
            // TODO: Add error cases 
            return RedirectToPage("/DisplayData", new { FullData = data });
        }
    }
}
