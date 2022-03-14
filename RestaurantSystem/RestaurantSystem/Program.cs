using RestaurantSystem.Models;

namespace RestaurantSystem
{
    internal class Program
    {
        static readonly RestaurantRepository Restaurant = new();
        
        static void Main(string[] args)
        {
            Restaurant.CreateRestaurantTables(10);
            var exitRestaurantSystem = false;
            while (!exitRestaurantSystem)
            {
                exitRestaurantSystem = Restaurant.MainWindow();
            }
        }
    }
}
