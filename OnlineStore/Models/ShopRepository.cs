using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Models
{


    public class ShopRepository : IShopRepository
    {
        private List<Section> _Sections { get; set; }

        public List<Section> Sections
        {
            get
            {
                if (_Sections == null)
                {
                    _Sections = new List<Section>
                    {
                        new Section(0, "Electronics", new List<Product>
                        {
                            new Product(0, "iPad", 10000, 0)
                        }),
                        new Section(1, "HouseholdChemicals", new List<Product>
                        {
                            new Product(1, "Laundry detergent", 10001, 1),
                            new Product(2, "Bleach", 10002, 1)
                        }),
                        new Section(2, "Cosmetics", new List<Product>
                        {
                            new Product(3, "Wash foam", 10004, 2),
                            new Product(4, "Hand cream", 10005, 2)
                        }),
                        new Section(3, "Shoes", new List<Product>
                        {
                            new Product(5, "Nike Air Force", 10005, 3),
                            new Product(6, "Stan Smith", 10006, 3)
                        })
                    };
                }

                return _Sections;
            }
        }

        public ShopRepository()
        {
        }
    }
}
