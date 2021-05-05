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

        public List<Section> Sections { get; set; }

        public SectionsController(ILogger<SectionsController> logger)
        {
            _logger = logger;
            Sections = new List<Section>();
            Sections.Add(new Section(0, "Электроника"));
            Sections.Add(new Section(2, "Товары для чистоты"));
            Sections.Add(new Section(3, "Косметика"));
            Sections.Add(new Section(4, "Обувь"));
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