using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Section
    {
        public Section(int id, string name, List<Product> goods)
        {
            Id = id;
            Name = name;
            Goods = goods;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Goods { get; set; }
    }
}
