using System.IO;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace OnlineStore.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult AddSection()
        {
            ViewBag.Title = "Добавление раздела";
            return View();
        }

        public IActionResult RemoveSection()
        {
            ViewBag.Title = "Удаление раздела";
            return View();
        }

        public IActionResult AddProduct()
        {
            ViewBag.Title = "Добавление нового товара";
            return View();
        }

        public IActionResult RemoveProduct()
        {
            ViewBag.Title = "Удаление товара";
            return View();
        }

        public async Task<IActionResult> GetDataFromSectionView(string sectionName, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string filePath = $"Files/{uploadedFile.FileName}";
                byte[] imageData;

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fs);
                    fs.Position = 0;
                    imageData = new byte[fs.Length];
                    await fs.ReadAsync(imageData.AsMemory(0, imageData.Length));
                }

                using (var db = new DataContext())
                {
                    db.Sections.Add(new Section(sectionName, new SectionImage(Path.GetFileName(uploadedFile.FileName), imageData)));
                    db.SaveChanges();
                }
            }
            return Redirect("~/");
        }

        public async Task<IActionResult> GetDataFromProductView(string productName, int article, int sectionId, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                string filePath = $"Files/{uploadedFile.FileName}";
                byte[] imageData;

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fs);
                    fs.Position = 0;
                    imageData = new byte[fs.Length];
                    await fs.ReadAsync(imageData.AsMemory(0, imageData.Length));
                }

                using (var db = new DataContext())
                {
                    db.Products.Add(new Product(productName, article, new ProductImage(Path.GetFileName(uploadedFile.FileName), imageData), sectionId));
                    db.SaveChanges();
                }
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

        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {
            using (var db = new DataContext())
            {
                db.Products.Remove(db.Products.FirstOrDefault(i => i.Id == id));
                db.SaveChanges();
            }
            return Redirect("~/");
        }
    }
}
