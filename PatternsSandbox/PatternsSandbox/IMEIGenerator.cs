using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    public sealed class IMEIGenerator
    {
        private static readonly IMEIGenerator _instance = new IMEIGenerator();
        private static int done = 0;
        public static IMEIGenerator Instance
        {
            get
            {
                return _instance;
            }
        }
        private IMEIGenerator(){}
        public string Generate(Phone phone)
        {
            done++;
            return phone.Brand.Length.ToString() + Convert.ToString(phone.Brand.GetHashCode()) + done + phone.Model.Length.ToString() + phone.AssemblyDate.Ticks;
            
        }
    }
}
