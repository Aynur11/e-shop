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
            Sections.Add(new Section(0, "Electronics"));
            Sections.Add(new Section(2, "HouseholdChemicals"));
            Sections.Add(new Section(3, "Cosmetics"));
            Sections.Add(new Section(4, "Shoes"));
        }

        public IActionResult GetView(int id)
        {
            return View(Sections[id].Name);
        }

        //public IActionResult Electronics()
        //{
        //    return View();
        //}

        //public IActionResult HouseholdChemicals()
        //{
        //    return View();
        //}

        //public IActionResult Cosmetics()
        //{
        //    return View();
        //}

        //public IActionResult Shoes()
        //{
        //    return View();
        //}
    }
}