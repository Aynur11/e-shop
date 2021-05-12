using System.Collections.Generic;

namespace OnlineStore.Models
{
    public class Section
    {
        public Section(int id, string name, List<string> goods)
        {
            Id = id;
            Name = name;
            Goods = goods;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Goods { get; set; }
    }
}
