using System.Collections.Generic;

namespace RestaurantSystem.Models
{
    public class Menu
    {
        public string Category { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public Menu()
        {
        }
        public List<Menu> GetAllMenuList(string fileName)
        {
            FileService fromFile = new(fileName);
            var menuFromFile = fromFile.GetAllLines();
            var newMenuList  = new List<Menu>();
            foreach (var str in menuFromFile)
            {
                var itemOnMenu = new Menu();
                string[] temp = str.Split(";");
                itemOnMenu.Category = temp[0];
                itemOnMenu.Description = temp[1];
                itemOnMenu.Price = ExceptionsHandle.FromStringToDouble(temp[2]);
                newMenuList.Add(itemOnMenu);
            }
            return newMenuList;
        }
        public override string ToString()
        {
            return $"{Description} - {Price} Eu";
        }
    }
}
