using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectionsSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input class type");
            foreach (var s in Assembly.GetAssembly(Type.GetType(Console.ReadLine())).GetTypes())
            {
                GetInfo(s);
            }
            Console.ReadKey();
        }

        static void GetInfo(Type t)
        {
            Console.WriteLine(t.ToString());
            foreach (var info in t.GetMethods())
            {
                Console.WriteLine(info.Name + " " + info.Attributes);
            }
            Console.WriteLine(t.IsSealed);
            Console.WriteLine(t.IsClass);
        }
    }
}
