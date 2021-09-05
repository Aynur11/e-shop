using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Dal.Models;

namespace OnlineStore.Api.Controllers
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

        [HttpPost("UpdateSection")]
        public void UpdateSection([FromBody] Section section)
        {
            var dbSection = Repository.Sections.FirstOrDefault(s => s.Id == section.Id);
            if (dbSection == null)
            {
                Debug.WriteLine("Обновляемая сущность не найдена.");
                return;
            }
            dbSection.Image = section.Image;
            dbSection.Name = section.Name;
            Repository.Save();
        }
    }
}
