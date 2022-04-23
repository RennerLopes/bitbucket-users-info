using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace alfasoft.bitbucketUsers.Console
{
    class Program
    {
        private static async Task ProcessUser(string userName)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.bitbucket.org/2.0/users/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            var stringTask = client.GetStringAsync(userName);
            var msg = await stringTask;
            Logger.WriteLog(msg);
            System.Console.Write("user: " + userName + "\n");
            System.Console.Write("url: " + client.BaseAddress + userName + "\n");
            System.Console.Write("Output: \n" + msg + "\n\n");
            client.Dispose();
        }

        static async Task Main(string[] args)
        {
            string path;
            List<string> users = new List<string>();

            System.Console.WriteLine("Enter the full path file: ");
            path = System.Console.ReadLine();

            using (StreamReader sr = File.OpenText(path))
            {
                string user;
                while ((user = sr.ReadLine()) != null)
                {
                    users.Add(user);
                }
            }

            var LastModified = File.GetLastWriteTime("/home/rennerlopes/Documents/Desafio Alfa soft/alfasoft.bitbucketUsers.Console/log.txt");

            if ((DateTime.Now - LastModified).TotalMilliseconds < 60000)
            {
                System.Console.Write("The program cannot make requests to the API because its last run is less than 60 seconds");
                Environment.Exit(0);
            }

            await Task.Run(async () =>
            {
                foreach (string user in users)
                {
                    await Task.Delay(5000);
                    await ProcessUser("70121:93728290-0f7b-4881-8bf2-896faefd398d");
                }
            });
        }
    }
}
