using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem.Models
{
    public class DrinksMenu : Menu
    {
        public List<Menu> DrinksList {get; set;}
        public DrinksMenu()
        {
            DrinksList = GetAllMenuList("DrinksMenu.txt");
        }
        public List<Menu> GetFilteredMenuByCategory(string category)
        {
            return DrinksList.Where(x => x.Category == category).ToList();
        }
    }
}
