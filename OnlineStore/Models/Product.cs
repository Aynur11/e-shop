using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace OnlineStore.Models
{
    public class Product
    {
        public Product(int id, string name, int article, int sectionId)
        {
            Id = id;
            Name = name;
            Article = article;
            SectionId = sectionId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Article { get; set; }
        public int SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
    }
}
