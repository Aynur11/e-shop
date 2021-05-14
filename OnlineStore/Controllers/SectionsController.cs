using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ILogger<SectionsController> _logger;
        public ShopRepository Repository { get; set; }


        public SectionsController(ILogger<SectionsController> logger)
        {
            _logger = logger;
            Repository = new ShopRepository();
        }

        public IActionResult Section(int id)
        {
            return View(Repository.GetSections().FirstOrDefault(e => e.Id == id));
        }

    }
}