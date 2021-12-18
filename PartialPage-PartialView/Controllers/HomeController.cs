using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartialPage_PartialView.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PartialPage_PartialView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<string> countries = new List<string>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            countries.Add("USA");
            countries.Add("UK");
            countries.Add("India");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GetPartial()
        {
            return PartialView("_CountriesPartial", countries);
        }
        public IActionResult GetSelectedPartial(string selectedCountry)
        {
            var finalCount = countries.FindAll(x => x.Contains(selectedCountry));
            return PartialView("_CountriesPartial", finalCount);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
