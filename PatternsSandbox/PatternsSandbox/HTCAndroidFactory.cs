using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    public sealed class HTCAndroidFactory: IPhoneFactory
    {
        private static readonly HTCAndroidFactory _instance = new HTCAndroidFactory();
        private HTCAndroidFactory() { }
        public Phone CreatePhone()
        {
            var phone = new Phone();
            phone.Brand = "HTC";
            phone.Model = "DesireHD";
            phone.Os = OS.Android;
            phone.Price = 800;
            phone.AssemblyDate = DateTime.Now;
            return phone;
        }

        public static Phone Create()
        {
            return _instance.CreatePhone();
        }
    }
}
