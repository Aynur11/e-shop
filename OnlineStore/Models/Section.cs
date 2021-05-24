using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Section
    {
        public Section(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}