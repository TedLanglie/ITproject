using Microsoft.AspNetCore.Mvc;
using System.Net;
using RequestPrototype.Models;
using Newtonsoft.Json;

namespace RequestPrototype.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
