using System;

namespace RestaurantSystem.Models
{
    public class RestaurantCheck : ICheck, IMail<MailService>
    {
        private static readonly FileService ToFile = new("RestaurantCheck.txt");
        private static readonly FileService ToHistoryFile = new("RestaurantCheckHistory.txt");
        public double TotalPrice { get; set; }
        public bool AddCheckToHistory { get; private set; }
        
        public RestaurantCheck(bool addCheckToHistory)
        {
            AddCheckToHistory = addCheckToHistory;
        }
        public void GenerateCheck(Table table)
        {
            TotalPrice = 0;
            var itemNumber = 1;
            var checkArray = new MyArray<string>();
            checkArray.AddElement($"Date {DateTime.Now:yyyy-MM-dd H:mm}");
            checkArray.AddElement("----------------------------");
            checkArray.AddElement($"Table No.{table.TableNo}, seats amount-{table.SeatsAmount}");
            foreach (Menu orderItem in table.OrderedItems)
            {
                checkArray.AddElement($"{itemNumber++}. {orderItem}");
                TotalPrice += orderItem.Price;
            }
            checkArray.AddElement("----------------------------");
            checkArray.AddElement($"Total price to pay - {Math.Round(TotalPrice, 2)} €");
            checkArray.AddElement("============================");

            ToFile.WriteAllText(checkArray.ConvertToStringArray());
            if (AddCheckToHistory) AddToHistoriCheck(checkArray.ConvertToStringArray());
            table.ClearOrderedItems();
            table.IsOccupied = false;
        }
        internal void AddToHistoriCheck(string[] checkArray)
        {
            foreach (var checkLine in checkArray)
            {
                ToHistoryFile.AppendText(checkLine);
            }
        }

        public void SendCheck(MailService email, bool isInternalMail)
        {
            email.SendEmail(ToFile.FileName, isInternalMail);
        }
    }
}
