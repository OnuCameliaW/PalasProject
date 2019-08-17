using System;
using System.Globalization;
using System.IO;

namespace Loggers
{
    public class ExceptionLogger
    {
        public static void Log(Exception ex)
        {
            using (StreamWriter streamWriter = new StreamWriter("ExceptionsLog.txt", true))
            {
                streamWriter.WriteLine(new string('-', 30));
                streamWriter.WriteLine("Date: " + DateTime.Now.ToString(CultureInfo.InvariantCulture));
                streamWriter.WriteLine();

                while (ex != null)
                {
                    streamWriter.WriteLine(ex.GetType().FullName);
                    streamWriter.WriteLine("Message: " + ex.Message);
                    streamWriter.WriteLine("StackTrace: " + ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }
    }
}
