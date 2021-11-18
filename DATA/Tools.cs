using System;
using System.IO;

namespace DATA
{
    class Tools
    {
        public static void WriteLog(Exception ex)
        {

            string filePath = System.Web.HttpContext.Current.Server.MapPath(".") + "\\ConsoleErrors\\";
            string crLf = Environment.NewLine;
            string fileName = filePath + "Error" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            string line2Write = DateTime.Now + "|" + crLf + ex.Source + "|" + crLf + ex.Message + "|" + crLf + ex.StackTrace + "|" + crLf + ex.InnerException;

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            using (StreamWriter SW = new StreamWriter(fileName, true))
            {
                SW.WriteLine(line2Write);
            }
        }
    }
}
