using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributesSandbox
{
    class Program
    {
        [StatusAttribute(StatusAttribute.Status.Fixed)] //Fixed!
        static void Main(string[] args)
        {
            var a = Attribute.GetCustomAttribute(typeof (Program), typeof (StatusAttribute));
            GiveMeBUGS();
            if (a != null)          //WTF!
            {
                  Console.WriteLine(((StatusAttribute)a).ToString());
            }
            Console.WriteLine("Hello world");
            Console.ReadKey();
            //GiveMeBUGS(); This thing is full of bugs
        }

        [StatusAttribute(StatusAttribute.Status.Bug)]
        static void GiveMeBUGS()
        {
            //return ololo; //BUG!
        }
    }
}
