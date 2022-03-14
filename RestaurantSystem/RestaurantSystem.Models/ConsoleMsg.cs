using System;

namespace RestaurantSystem.Models
{
    public static class ConsoleMsg
    {
        public static void WrongInputMsg()
        {
            Console.WriteLine("Wrong input!!! press anny key to continue");
            Console.ReadKey();
        }
        public static void ContinueMsg()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Press anny key to continue");
            Console.ReadKey();
        }
        public static void BackToPreviouslyWindowMsg(int commandNumber)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{commandNumber} - Go back to previously window");
            Console.WriteLine("---------------------------------------------------");
        }
        public static void ExitSystemMsg(int commandNumber)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"{commandNumber} - To exit reataurant system");
            Console.WriteLine("---------------------------------------------------");
        }
        public static void TableNotOccupiedMsg()
        {
            Console.WriteLine("Tabe is net occupied, no check to print");
            Console.WriteLine("Press anny key to continue");
            Console.ReadKey();
        }
    }
}
