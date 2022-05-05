using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using RequestPrototype.Models;

namespace RequestPrototype.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // the query string. Symbol should become variables that are user inputed. (maybe function too but probably not)
            string QUERY_URL = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=IBM&interval=5min&apikey=3HAONZ71TFYS0307";
            Uri queryUri = new Uri(QUERY_URL);

            using (WebClient client = new WebClient())
            {
                // json_data is the result of querying the data
                dynamic json_data = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(client.DownloadString(queryUri));

                // create list of all data from JSON response
                List<string> keyList = new List<string>(json_data.Keys);
                List<dynamic> dynamicList = new List<dynamic>();
                foreach (var val in json_data)
                {
                    dynamicList.Add(val);
                }

                // create stockData model to hold JSON reponse
                stockData stockData = new stockData
                {
                    metaData = keyList,   
                    stocks = dynamicList
                };
                // use this to pass data to the view
                ViewBag.Message = stockData;

                return View();
            }

        }
    }
}
