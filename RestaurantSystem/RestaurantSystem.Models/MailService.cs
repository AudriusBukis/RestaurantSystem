using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace RestaurantSystem.Models
{ 
    public class MailService
    {
        private readonly SmtpClient SmtpServer = new("smtp.gmail.com");
        private readonly Regex EmailRegexValidator = new("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
        private readonly FileService GetEmailLogin = new("mail.dat");
        public void SendEmail(string fileName, bool isInternalMail)
        {
            int mail = 0;
            int password = 1; 
            MailMessage mailMsg = new();
            var filePath = new FilePath(fileName);
            var getLogin = GetEmailLogin.GetAllLines();
            mailMsg.From = new MailAddress(getLogin[mail]);
            if (isInternalMail) mailMsg.To.Add(getLogin[mail]);
            else mailMsg.To.Add(EmailValidation());
            mailMsg.Subject = "Restaurant check";
            mailMsg.Body = $"Restaurant check date:{DateTime.Now:yyyy-MM-dd H:mm}";
            mailMsg.Attachments.Add(new Attachment(filePath.Path));
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential(getLogin[mail], getLogin[password]);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mailMsg);

        }
        public string EmailValidation()
        {
            while (true)
            {
                Console.WriteLine("enter yuor email");
                string enteredEmail = Console.ReadLine();
                Console.WriteLine("Started validation of email:");
                if (EmailRegexValidator.IsMatch(enteredEmail))
                {
                    Console.WriteLine("Validated. mail sended");
                    return enteredEmail;
                }
                else
                {
                    Console.WriteLine("Not valid email address, press any key to continue");
                    Console.ReadKey();
                }
              

            }
        }
    }
}
