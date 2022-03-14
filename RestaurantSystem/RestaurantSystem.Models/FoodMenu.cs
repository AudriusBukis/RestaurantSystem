using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem.Models
{
    public class FoodMenu : Menu
    {
        public List<Menu> FoodList { get; set; }
        public FoodMenu()
        {
            FoodList = GetAllMenuList("FoodMenu.txt");
        }
        public List<Menu> GetFilteredMenuByCategory(string category)
        {
            return FoodList.Where(x => x.Category == category).ToList();
        }
    }
}
