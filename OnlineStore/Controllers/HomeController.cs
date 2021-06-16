using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using System.Diagnostics;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IShopRepository Repository { get; set; }


        public HomeController(ILogger<HomeController> logger, IShopRepository repository)
        {
            _logger = logger;
            Repository = repository;
        }

        public IActionResult Index()
        {
            return View(Repository.Sections);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Manage()
        {
            ViewBag.Title = "Управление контентом";
            return View();
        }

        public ActionResult ProductsSearch(string name)
        {
            var products = Repository.Sections.Where(a => a.Name.Contains(name)).SelectMany(p => p.Products).ToList();
            return PartialView(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
