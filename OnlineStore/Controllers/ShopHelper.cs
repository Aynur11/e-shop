using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class ShopHelper
    {
        public static List<ShopSection> GetSections()
        {
            List<ShopSection> shopSections = new List<ShopSection>();
            shopSections.Add(new ShopSection("Electronics", "Электроника",
                "Телефоны, смартфоны\nНоутбуки\nКамеры\nИ другие гаджеты"));

            shopSections.Add(new ShopSection("HouseholdChemicals", "Товары для чистоты", 
                "Стиральные порошки\nГели, концентраты" + 
                "\nКондиционеры для белья\nКапсулы для стирки\nКапсулы для посудомоечных машин"));

            shopSections.Add(new ShopSection("Cosmetics", "Косметика", 
                "Шампуни\nГели для душа\nКрема для рук, лица и тела\nМасла для тела\nМаски для лица"));

            shopSections.Add(new ShopSection("Shoes", "Обувь", "Кросовки\nКеды\nТуфли"));
            return shopSections;
        }
    }
}