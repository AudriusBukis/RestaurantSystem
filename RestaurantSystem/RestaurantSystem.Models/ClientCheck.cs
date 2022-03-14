using System;

namespace RestaurantSystem.Models
{
    public class ClientCheck : ICheck, IMail<MailService>
    {
        private static readonly FileService ToFile = new("ClientCheck.txt");
        public double TotalPrice { get ; set ; }
        public bool CheckIsRequired { get ; set ; }
        public void GenerateCheck(Table table)
        {
            TotalPrice = 0;
            var itemNumber = 1;
            ToFile.WriteAllText(new string[] {});
            ToFile.AppendText("------My Restoraunt--------");
            ToFile.AppendText($"Date {DateTime.Now:yyyy-MM-dd H:mm}");
            ToFile.AppendText("----------------------------");
            foreach (Menu orderItem in table.OrderedItems)
            {
                ToFile.AppendText($"{itemNumber++}. {orderItem}");
                TotalPrice += orderItem.Price;
            }
            ToFile.AppendText("----------------------------");
            ToFile.AppendText($"Total price to pay - {Math.Round(TotalPrice, 2)} €");
            ToFile.AppendText("============================");
            
        }
        public void SendCheck(MailService email, bool isInternalMail)
        {
            email.SendEmail(ToFile.FileName, isInternalMail);
        }
    }
}
