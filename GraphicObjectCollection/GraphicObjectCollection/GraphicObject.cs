using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;


namespace GraphicObjectCollection
{
    [Serializable]
    [DataContract]
    public class GraphicObject
    {
        [XmlIgnore]
        public ObjectContainer Container { get; set; }
        [DataMember]
        public int RotationAngle { get; set; }

        public GraphicObject()
        {
            Container = null;
            GlobalX = 0;
            GlobalY = 0;
            ZBuffer = 0;
            Graphics = null;
            RotationAngle = 0;
            IsParalax = false;
        }
        [DataMember]
        public int GlobalX { get; set; }
        [DataMember]
        public int GlobalY { get; set; }
        [DataMember]
        [XmlAttribute("X")]
        public int LocalX { get; set; }
        [DataMember]
        [XmlAttribute("Y")]
        public int LocalY { get; set; }
        [DataMember]
        [XmlAttribute("Z")]
        public int ZBuffer { get; set; }
        [DataMember]
        public bool IsParalax { get; set; }
        [XmlIgnore]
        public Bitmap Graphics;

        public void Draw()
        {
            Console.WriteLine("* X:{0} Y:{1}", this.GlobalX, this.GlobalY);
        }
        public void Move(int x, int y)
        {
            this.GlobalX = x;
            this.GlobalY = y;
        }

        public byte[] ToByte()
        {
            byte[] array = { (byte)ZBuffer, (byte)GlobalX, (byte)GlobalY };
            return array;
        }
    }
}