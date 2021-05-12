using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{
    public class Home
    {
        public List<Section> Sections { get; set; }

        public Home()
        {
            Sections = new List<Section>();
            Sections.Add(new Section(0, "Electronics", new List<string> { "iPad", "iPhone" }));
            Sections.Add(new Section(2, "HouseholdChemicals", new List<string> { "Laundry detergent", "Bleach" }));
            Sections.Add(new Section(3, "Cosmetics", new List<string> { "Wash foam", "Hand cream" }));
            Sections.Add(new Section(4, "Shoes", new List<string> { "Nike Air Force", "Boots", "Stan Smith" }));
        }
    }
}
