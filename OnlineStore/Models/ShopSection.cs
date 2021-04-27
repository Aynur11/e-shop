using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class ShopSection
    {
        public ShopSection(string view, string name, string description)
        {
            View = view;
            Name = name;
            Description = description;
        }

        public string View { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}