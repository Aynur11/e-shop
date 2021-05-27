using System.IO;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Linq;

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

        public IActionResult GetDataFromSectionView(string sectionName, string filePath)
        {
            using (var db = new DataContext())
            {
                byte[] imageData;
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    imageData = new byte[fs.Length];
                    fs.Read(imageData, 0, imageData.Length);
                }
                db.Sections.Add(new Section(sectionName, new SectionImage(Path.GetFileName(filePath), imageData)));
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
