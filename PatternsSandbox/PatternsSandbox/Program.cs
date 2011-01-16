using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var pd = new PhoneDirectory();
            pd.List.Add(HTCAndroidFactory.Create());
            pd.List.Add(HTCWP7Factory.Create());
            pd.List.Add(AppleFactory.Create());
            pd.List.Add(AppleFactory.Create());
            pd.List.Add(HTCWP7Factory.Create());
            pd.List.Add(AppleFactory.Create());
            pd.List.Add(HTCAndroidFactory.Create());
            pd.List.Add(HTCAndroidFactory.Create());
            pd.List.Add(HTCAndroidFactory.Create());
            pd.List.Add(HTCAndroidFactory.Create());
            pd.List.Add(AppleFactory.Create());

            foreach (var phone in pd.List)
                Console.WriteLine("Brand: {0} \nModel: {1} \nAssemblyDate: {2} \nIMEI: {3} \nPrice: {4}", phone.Brand, phone.Model, phone.AssemblyDate.ToString(), phone.IMEI, phone.Price);

            pd.XmlSerialization();
            pd.BinarySerialization();

            Console.ReadKey();
 
 

        }
    }
}
