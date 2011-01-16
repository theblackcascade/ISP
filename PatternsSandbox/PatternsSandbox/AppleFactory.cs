using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    public sealed class AppleFactory : IPhoneFactory
    {
        private static readonly AppleFactory _instance = new AppleFactory();
        private AppleFactory() { }
        public Phone CreatePhone()
        {
            var phone = new Phone();
            phone.Brand = "Apple";
            phone.Model = "iPhone 4";
            phone.Os = OS.iOS;
            phone.Price = 1000;
            phone.AssemblyDate = DateTime.Now;
            return phone;
        }
        public static Phone Create()
        {
            return _instance.CreatePhone();
        }
    }
}
