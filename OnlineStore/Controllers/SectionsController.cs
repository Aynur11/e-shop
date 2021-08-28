using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using System.Linq;
using System.Net.Http;

namespace OnlineStore.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ILogger<SectionsController> _logger;
        public ShopApiClient Repository { get; set; }


        public SectionsController(ILogger<SectionsController> logger, DataContext context, HttpClient httpClient)
        {
            _logger = logger;
            Repository = new ShopApiClient(context, httpClient);
        }

        public IActionResult Sections(int id)
        {
            return View(Repository.Sections.First(e => e.Id == id));
        }

    }
}