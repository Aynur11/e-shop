using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApi.Models
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, int article, ProductImage image, int sectionId)
        {
            Name = name;
            Article = article;
            Image = image;
            SectionId = sectionId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Article { get; set; }
        public int SectionId { get; set; }
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }
        public int ProductImageId { get; set; }
        [ForeignKey(nameof(ProductImageId))]
        public ProductImage Image { get; set; }

    }
}
