using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;
using System.Linq;

namespace OnlineStore.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ILogger<SectionsController> _logger;
        public ShopRepository Repository { get; set; }


        public SectionsController(ILogger<SectionsController> logger, DataContext context)
        {
            _logger = logger;
            Repository = new ShopRepository(context);
        }

        public IActionResult Sections(int id)
        {
            return View(Repository.Sections.First(e => e.Id == id));
        }

    }
}