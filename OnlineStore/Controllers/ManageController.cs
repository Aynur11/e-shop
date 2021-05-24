using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult AddNewSection()
        {
            ViewBag.Title = "Добавление раздела";
            return View();
        }

        public IActionResult RemoveSection()
        {
            ViewBag.Title = "Удаление раздела";
            return View();
        }

        public IActionResult GetDataFromSectionView(string name)
        {
            using (var db = new DataContext())
            {
                db.Sections.Add(
                    new Section(name));
                db.SaveChanges();
            }

            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult RemoveSection(int id)
        {
            using (var db = new DataContext())
            {
                db.Sections.Remove(db.Sections.FirstOrDefault(i => i.Id == id));
                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
