using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using System.Collections.Generic;

namespace StoreApi.Controllers
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
    }
}
