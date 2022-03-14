using System;
using System.Globalization;
using System.IO;

namespace RestaurantSystem.Models
{
    public class ExceptionsHandle
    {
        internal static readonly FilePath ToFile = new("ErrorLog.txt");
        
        public static void Logging(string exMessage, string exStackTrace)
        {
            if (!File.Exists(ToFile.Path))
            {
                File.Create(ToFile.Path).Dispose();
            }
            using (StreamWriter sw = File.AppendText(ToFile.Path))
            {
                sw.WriteLine("========Error Start======== " + DateTime.Now);
                sw.WriteLine("Error Message: " + exMessage);
                sw.WriteLine("Stack Trace: " + exStackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);
            }
        }
        public static double FromStringToDouble(string str)
        {
            try
            {
                return Double.Parse(str, CultureInfo.InvariantCulture);
            }
            catch (FormatException ex)
            {
                Logging(ex.Message, ex.StackTrace);
                return default;
            }
            catch (ArgumentNullException ex)
            {
                Logging(ex.Message, ex.StackTrace);
                return default;
            }
            catch (ArgumentException ex)
            {
                Logging(ex.Message, ex.StackTrace);
                return default;
            }
        }
        
    }
}
