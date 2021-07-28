using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using System.Collections.Generic;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        public IShopRepository Repository { get; set; }

        public HomeController(IShopRepository repo)
        {
            Repository = repo;
        }

        [HttpGet("GetSections")]
        public List<Section> GetSections() => Repository.Sections;

        [HttpGet("GetProducts")]
        public List<Product> GetProducts() => Repository.Products;

        [HttpGet("GetProductImages")]
        public List<ProductImage> GetProductImages() => Repository.ProductImages;

        [HttpPost("AddSection")]
        public void AddSection([FromBody] Section section)
        {
            Repository.Add(section);
            Repository.Save();
        }

        [HttpPost("AddProduct")]
        public void AddProduct([FromBody] Product product)
        {
            Repository.Add(product);
            Repository.Save();
        }

        [HttpPost("RemoveSection")]
        public void RemoveSection([FromBody] Section section)
        {
            Repository.Remove(section);
            Repository.Save();
        }

        [HttpPost("RemoveProduct")]
        public void RemoveProduct([FromBody] Product product)
        {
            Repository.Remove(product);
            Repository.Save();
        }
    }
}
