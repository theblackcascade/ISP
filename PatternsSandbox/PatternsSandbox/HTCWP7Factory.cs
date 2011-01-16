using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    public sealed class HTCWP7Factory : IPhoneFactory
    {
        private static readonly HTCWP7Factory _instance = new HTCWP7Factory();
        private HTCWP7Factory() { }
        public Phone CreatePhone()
        {
            var phone = new Phone();
            phone.Brand = "HTC";
            phone.Model = "HD7";
            phone.Os = OS.WP7;
            phone.Price = 900;
            phone.AssemblyDate = DateTime.Now;
            return phone;
        }
        public static Phone Create()
        {
            return _instance.CreatePhone();
        }
        
    }
}
