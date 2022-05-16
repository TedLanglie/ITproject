using Microsoft.AspNetCore.Mvc;
using System.Net;
using RequestPrototype.Models;
using Newtonsoft.Json;

namespace RequestPrototype.Controllers
{
    public class HomeController : Controller
    {
        private ISymbolCompanyRepository repo;

        public HomeController(ISymbolCompanyRepository repo) 
        {
            this.repo = repo;
        }

        public IActionResult Index() => View();
    }
}
