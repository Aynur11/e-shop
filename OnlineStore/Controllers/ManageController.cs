using System.IO;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult AddSection()
        {
            ViewBag.Title = "Добавление раздела";
            return View();
        }
        public IActionResult EditSection()
        {
            ViewBag.Title = "Редактирвоание раздела";
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

        public IActionResult EditProduct()
        {
            ViewBag.Title = "Редактирование товара";
            return View();
        }

        public IActionResult RemoveProduct()
        {
            ViewBag.Title = "Удаление товара";
            return View();
        }

        public IActionResult EntityNotFound()
        {
            return View();
        }

        public async Task<IActionResult> GetDataFromSectionEditView(int id, string sectionName, IFormFile uploadedFile)
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

                using (var repo = new ShopRepository())
                {
                    var section = repo.Sections.FirstOrDefault(i => i.Id == id);
                    if (section != null)
                    {
                        section.Name = sectionName;
                        section.Image.ImageName= uploadedFile.FileName;
                        section.Image.Data = imageData;
                        repo.Save();
                        return Redirect("~/");
                    }
                }
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return Redirect("EntityNotFound");
        }

        public async Task<IActionResult> GetDataFromProductEditView(int id, string productName, int article, int sectionId, IFormFile uploadedFile)
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

                using (var repo = new ShopRepository())
                {
                    var product = repo.Products.FirstOrDefault(i => i.Id == id);
                    if (product != null)
                    {
                        product.Name = productName;
                        product.Article = article;
                        product.SectionId = sectionId;
                        product.Image.ImageName = uploadedFile.FileName;
                        product.Image.Data = imageData;
                        repo.Save();
                        return Redirect("~/");
                    }
                }

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return Redirect("~/");
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

                using (var repo = new ShopRepository())
                {
                    repo.Add(new Section(sectionName, new SectionImage(Path.GetFileName(uploadedFile.FileName), imageData)));
                    repo.Save();
                }
 
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
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

                using (var repo = new ShopRepository())
                {
                    repo.Add(new Product(productName, article, new ProductImage(Path.GetFileName(uploadedFile.FileName), imageData), sectionId));
                    repo.Save();
                }
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            return Redirect("~/");
        }

        [HttpPost]
        public IActionResult RemoveSection(int id)
        {
            using (var repo = new ShopRepository())
            {
                var section = repo.Sections.FirstOrDefault(i => i.Id == id);
                if (section != null)
                {
                    repo.Remove(section);
                    repo.Save();
                    return Redirect("~/");

                }
                return Redirect("EntityNotFound");
            }
        }

        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {
            using (var repo = new ShopRepository())
            {
                var product = repo.Products.FirstOrDefault(i => i.Id == id);
                if (product != null)
                {
                    if (product.Image != null)
                    {
                        repo.ProductImages.Remove(product.Image);
                    }
                    repo.Remove(product);
                    repo.Save();
                    return Redirect("~/");
                }
                return Redirect("EntityNotFound");
            }
        }
    }
}
