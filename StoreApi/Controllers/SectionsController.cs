using Microsoft.AspNetCore.Mvc;
using StoreApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Net.Http.Headers;

namespace StoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectionsController : Controller
    {
        public IShopRepository Repository { get; set; }

        public SectionsController(IShopRepository repo)
        {
            Repository = repo;
        }

        [HttpGet("GetSections")]
        public List<Section> GetSections() => Repository.Sections;

        [HttpPost("AddSection")]
        public void AddSection([FromBody] Section section)
        {
            Repository.Add(section);
            Repository.Save();
        }

        [HttpPost("RemoveSection")]
        public void RemoveSection([FromBody] Section section)
        {
            Repository.Remove(section);
            Repository.Save();
        }
    }
}
