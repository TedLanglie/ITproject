﻿using Microsoft.AspNetCore.Mvc;

namespace RequestPrototype.Controllers
{
    public class GeneralController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
