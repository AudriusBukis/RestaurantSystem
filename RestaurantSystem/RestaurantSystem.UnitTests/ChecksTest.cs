using RestaurantSystem.Models;
using System.Linq;
using Xunit;

namespace RestaurantSystem.UnitTests
{
    public class ChecksTest
    {
        [Fact]
        public void Test_If_TotalPrice_In_Checks_Are_Calculated_Equaly()
        {
            var newDrinkMenu = new DrinksMenu();
            var newTable = new Table();
            var listDrinksMenuCategory = newDrinkMenu.DrinksList.GroupBy(drinkItem => drinkItem.Category)
                                                             .Select(drinkCategory => drinkCategory.First())
                                                             .ToList();
            newTable.OrderedItems.AddRange(newDrinkMenu.GetFilteredMenuByCategory($"{listDrinksMenuCategory[0].Category}"));
            var newClientCheck = new ClientCheck();
            var newRestaurantCheck = new RestaurantCheck(false);

            newClientCheck.GenerateCheck(newTable);
            newRestaurantCheck.GenerateCheck(newTable);


            Assert.Equal(newClientCheck.TotalPrice, newRestaurantCheck.TotalPrice);
        }
    }
}
