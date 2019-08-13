using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleText.Models;
// using SimpleText.data;

namespace myFirstAzureWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        /*
        [HttpPost]
        public IActionResult FormText(string formText)
        {
            string authData = $"Text: {formText}";
            GetText.PText = formText;
            return Content(authData);
        }
        */
    }
}
