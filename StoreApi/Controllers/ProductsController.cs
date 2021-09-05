using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Api.Models;

namespace OnlineStore.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        public IShopRepository Repository { get; set; }

        public ProductsController(IShopRepository repo)
        {
            Repository = repo;
        }
        
        [HttpGet("GetProducts")]
        public List<Product> GetProducts() => Repository.Products;

        [HttpGet("GetProductImages")]
        public List<ProductImage> GetProductImages() => Repository.ProductImages;

        [HttpPost("AddProduct")]
        public void AddProduct([FromBody] Product product)
        {
            Repository.Add(product);
            Repository.Save();
        }
        
        [HttpPost("RemoveProduct")]
        public void RemoveProduct([FromBody] Product product)
        {
            Repository.Remove(product);
            Repository.Save();
        }

        [HttpPost("UpdateProduct")]
        public void UpdateProduct([FromBody] Product product)
        {
            var dbProduct = Repository.Products.FirstOrDefault(s => s.Id == product.Id);
            if (dbProduct == null)
            {
                Debug.WriteLine("Обновляемая сущность не найдена.");
                return;
            }
            dbProduct.Image.ImageName = product.Image.ImageName;
            dbProduct.Image.Data = product.Image.Data;
            dbProduct.Name = product.Name;
            Repository.Save();
        }
    }
}
