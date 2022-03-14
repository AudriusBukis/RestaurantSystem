using System;
using System.Linq;

namespace RestaurantSystem.Models
{
    public class TableRepository
    {
        public  DrinksMenu drinksMenu = new();
        public  FoodMenu foodMenu = new();

        public void OrderingWindow(Table table)
        {
            var exit = false;
            var userInput = "";
            var listDrinksMenuCategory = drinksMenu.DrinksList.GroupBy(drinkItem => drinkItem.Category)
                                                              .Select(drinkCategory => drinkCategory.First())
                                                              .ToList();
            var listFoodMenuCategory = foodMenu.FoodList.GroupBy(foodItem => foodItem.Category)
                                                        .Select(foodCategoty => foodCategoty.First())
                                                        .ToList();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Choose what they want to order Table No.{table.TableNo}");
                Console.WriteLine("Food Menu");
                for (int i = 0; i < listFoodMenuCategory.Count; i++)
                {
                    Console.WriteLine($"{i+1} - {listFoodMenuCategory[i].Category}");
                }
                Console.WriteLine("Drinks Menu");
                for (int i = 0; i < listDrinksMenuCategory.Count; i++)
                {
                    Console.WriteLine($"{i+listFoodMenuCategory.Count + 1} - {listDrinksMenuCategory[i].Category}");
                }
                ConsoleMsg.BackToPreviouslyWindowMsg(listDrinksMenuCategory.Count + listDrinksMenuCategory.Count + 1);
                userInput = Console.ReadLine().ToLower().Trim();
                if (userInput == $"{listDrinksMenuCategory.Count + listDrinksMenuCategory.Count + 1}")
                {
                    exit = true;
                    continue;
                }
                if (Int32.TryParse(userInput, out int command))
                {
                    if ((command > 0) && (command <= listFoodMenuCategory.Count))
                    {
                        ShowFoodMenuAndOrderIt(table, listFoodMenuCategory[command - 1].Category);

                    }
                    else if ((command > listFoodMenuCategory.Count) && (command <= listFoodMenuCategory.Count + listDrinksMenuCategory.Count))
                    {
                        ShowDrinksMenuAndOrderIt(table, listDrinksMenuCategory[command - listFoodMenuCategory.Count - 1].Category);
                    }
                    else ConsoleMsg.WrongInputMsg();
                }
                else ConsoleMsg.WrongInputMsg();
            }
            
        }
        internal void ShowDrinksMenuAndOrderIt(Table table, string menuName)
        {
            var listDrinks = drinksMenu.GetFilteredMenuByCategory(menuName);
            while(true)
            {
                Console.Clear();
                Console.WriteLine($"Take drinks orders from category {menuName}");
                foreach (var item in listDrinks)
                {
                    Console.WriteLine($"{listDrinks.IndexOf(item) + 1} - {item}");
                }
                ConsoleMsg.BackToPreviouslyWindowMsg(listDrinks.Count + 1);
                var userInput = Console.ReadLine().ToLower().Trim(); 
                if (userInput == $"{listDrinks.Count+1}") break;
                if (Int32.TryParse(userInput, out int command))
                {
                    if ((command <= listDrinks.Count) && (command > 0))
                    {
                        table.AddItemToOrder(listDrinks.ElementAt(command - 1));
                        table.IsOccupied = true;
                    }
                    else ConsoleMsg.WrongInputMsg();
                    
                }
                else ConsoleMsg.WrongInputMsg();
            }

        }
        internal void ShowFoodMenuAndOrderIt(Table table, string menuName)
        {
            var listDish = foodMenu.GetFilteredMenuByCategory(menuName);
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Take Food orders from category {menuName}");
                foreach (var item in listDish)
                {
                    Console.WriteLine($"{listDish.IndexOf(item) + 1} - {item}");
                }
                ConsoleMsg.BackToPreviouslyWindowMsg(listDish.Count + 1);
                var userInput = Console.ReadLine().ToLower().Trim(); 
                if (userInput == $"{listDish.Count+1}") break;
                if (Int32.TryParse(userInput, out int command))
                {
                    if ((command <= listDish.Count) && (command > 0))
                    {
                        table.AddItemToOrder(listDish.ElementAt(command - 1));
                        table.IsOccupied = true;
                    }
                    else ConsoleMsg.WrongInputMsg();

                }
                else ConsoleMsg.WrongInputMsg();
            }

        }
    }
}
