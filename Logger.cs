using System;
using System.IO;

namespace alfasoft.bitbucketUsers.Console
{
    public static class Logger
    {
        public static void WriteLog(string message)
        {
            string logPath = "/home/rennerlopes/Documents/Desafio Alfa soft/alfasoft.bitbucketUsers.Console/log.txt";
            using (StreamWriter write = new StreamWriter(logPath, true))
            {
                write.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }
}