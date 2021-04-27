using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace OnlineStore.Controllers
{
    public class SectionsController : Controller
    {
        private readonly ILogger<SectionsController> _logger;

        public SectionsController(ILogger<SectionsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Electronics()
        {
            return View();
        }

        public IActionResult HouseholdChemicals()
        {
            return View();
        }

        public IActionResult Cosmetics()
        {
            return View();
        }

        public IActionResult Shoes()
        {
            return View();
        }
    }
}