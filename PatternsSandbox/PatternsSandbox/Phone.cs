using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternsSandbox
{
    public enum OS
    {
        Android, //htc samsung
        WP7,  //htc samsung 
        iOS,  //apple
        Bada, //samsung
        Meego //nokia
    }
    [Serializable]
    public class Phone
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public OS Os { get; set; }
        public int Price { get; set; }
        public DateTime AssemblyDate { get; set; }
        public string IMEI
        {
            get
            {
                return IMEIGenerator.Instance.Generate(this);
            }
        }
        public Phone() { }
    }
}
