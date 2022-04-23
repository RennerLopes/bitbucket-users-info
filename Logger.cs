using System;
using System.IO;

namespace alfasoft.bitbucketUsers.Console
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logName = "log.txt";
            string logPath = Path.GetFullPath(logName);
            using (StreamWriter write = new StreamWriter(logPath, true))
            {
                write.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}