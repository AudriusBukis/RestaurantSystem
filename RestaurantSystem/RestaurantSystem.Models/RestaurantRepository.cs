using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantSystem.Models
{
    public class RestaurantRepository
    {
        public List<Table> Tables = new();
        public TableRepository TableOrder = new();
        public bool MainWindow()
        {
            string userInput;
            Console.Clear();
            Console.WriteLine("Welcome, to restaurant management system");
            Console.WriteLine("choose the table you want to work with ");
            Console.WriteLine("--------------------------------------------------------");
            Tables.ForEach(table => Console.WriteLine(table));
            ConsoleMsg.ExitSystemMsg(Tables.Count + 1);
            userInput = Console.ReadLine().ToLower().Trim();
            if (userInput == $"{Tables.Count + 1}") return true;
            else if (Int32.TryParse(userInput, out int tableNo))
            {
                WorkWithTable(tableNo);
                return false;
            }
            else
            {
                ConsoleMsg.WrongInputMsg();
                return false;
            }
        }
        public void CreateRestaurantTables(int numberOfTables)
        {
            for (int i = 0; i < numberOfTables; i++)
            {
                Tables.Add(new Table());
            }
        }
        public void WorkWithTable(int tableNo)
        {
            var exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"Choose what you want to do with Table No.{tableNo}");
                Console.WriteLine("1 - Free the table (check print)");
                Console.WriteLine("2 - Take order (Add to order)");
                Console.WriteLine("3 - View table order");
                ConsoleMsg.BackToPreviouslyWindowMsg(4);
                var table = Tables.Where(t => t.TableNo == (tableNo)).First();
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if (command == 1)
                    {
                        if (table.IsOccupied) CheckPrint(table);
                        else ConsoleMsg.TableNotOccupiedMsg();
                    }
                    else if (command == 2) TableOrder.OrderingWindow(table);
                    else if (command == 3) ViewTableOrder(table);
                    else if (command == 4) exit = true;
                    else ConsoleMsg.WrongInputMsg();
                }
                else ConsoleMsg.WrongInputMsg();
            }
        }
        internal void CheckPrint(Table table)
        {
            var restaurantCheck = new RestaurantCheck(true);
            var clientCheck = new ClientCheck();
           
            clientCheck.GenerateCheck(table);
            restaurantCheck.GenerateCheck(table);

            while (true)
            {
                Console.WriteLine("Do client need check ?");
                Console.WriteLine(" 1 - Yes");
                Console.WriteLine(" 2 - No");
                if (Int32.TryParse(Console.ReadLine(), out int command))
                {
                    if (command == 1)
                    {
                        clientCheck.SendCheck(new MailService(), false);
                        restaurantCheck.SendCheck(new MailService(), true);
                        break;
                    }
                    else if (command == 2)
                    {
                        restaurantCheck.SendCheck(new MailService(), true);
                        break;
                    }
                    else if (command == 3)
                    {
                        break;
                    }
                    else ConsoleMsg.WrongInputMsg();
                }
                else ConsoleMsg.WrongInputMsg();
            }
        }
        internal void ViewTableOrder(Table table)
        {
            Console.WriteLine($"Curently teble No.{table.TableNo} is ordered");
            var itemNumber = 1;
            foreach (var orderedItem in table.OrderedItems)
            {
                
                Console.WriteLine($"{itemNumber++} - {orderedItem}");
            }
            ConsoleMsg.ContinueMsg();
        }
       

    }
}
