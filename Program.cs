using System;
using System.Collections.Generic;
using System.IO;

namespace alfasoft.bitbucketUsers.Console
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
