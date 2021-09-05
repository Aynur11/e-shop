using System.Collections.Generic;

namespace OnlineStore.Dal.Models
{
    public class Section
    {
        public Section()
        {
        }

        public Section(string name, SectionImage image)
        {
            Name = name;
            Image = image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public SectionImage Image { get; set; }
        public List<Product> Products { get; set; }
    }
}