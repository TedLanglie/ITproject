using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

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

                // for now I just pass all the data to a view, but this isn't how it should be. We need to do something with this data perhaps with Models. pretty much we have the data now,
                // and just need to make use of it inside the view (the html page). You can just loop through the data model and print it all, it should be fairly simple.
                // we might have to change Figure 1.1 to be an action that doesn't call index but a different razor page. Then we use this action result as a call to bring up the home page
                // for now, lets just try to get the json data gathered here, onto a view. Preferrably using models.
                return View(json_data);
            }

        }
    }
}
