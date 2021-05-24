using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Section
    {
        public Section(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}