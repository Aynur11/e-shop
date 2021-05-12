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
        public Home HomeModel { get; set; }

        public SectionsController(ILogger<SectionsController> logger)
        {
            _logger = logger;
           
        }

        public IActionResult GetView(int id)
        {
            HomeModel = new Home();
            return View(HomeModel.Sections[id].Name);
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