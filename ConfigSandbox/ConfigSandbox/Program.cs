using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Configuration.Assemblies;      
namespace ConfigSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List();
            Console.ReadKey();
        }

        static void List()
        {
            var cfg = ConfigurationManager.OpenExeConfiguration("doit.exe");
            Console.WriteLine(cfg.AppSettings.ElementInformation.ToString());

        }
    }
}
