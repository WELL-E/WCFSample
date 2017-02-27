using System;
using System.IO;
using System.Reflection;

namespace WCF.Common
{
    public class LogHelper
    {
        private static readonly string FilePath;

        static LogHelper()
        {
            FilePath = string.Format("{0}/app.log", Path.GetDirectoryName(Assembly.GetEntryAssembly().Location));
        }

        public static void Debug(string msg)
        {
            var sw = File.AppendText(FilePath);

            try
            {
                var logLine = string.Format("{0:G}: {1}.", DateTime.Now, msg);
                sw.WriteLine(logLine);
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
