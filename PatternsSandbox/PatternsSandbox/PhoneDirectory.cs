using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace PatternsSandbox
{
    class PhoneDirectory
    {
        public List<Phone> List = new List<Phone>();

        public void BinarySerialization()
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.Create("phones.bin"))
            {
                formatter.Serialize(stream, List);
            }
        }
        public void BinaryDeserialization()
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.OpenRead("phones.bin"))
            {
                List = (List<Phone>)formatter.Deserialize(stream);
            }
        }
        public void XmlSerialization()
        {
            var serializer = new XmlSerializer(typeof(List<Phone>));
            using (var stream = File.Create("phones.xml"))
            {
                serializer.Serialize(stream, List);
            }
        }
        public void XmlDeserialization()
        {
            var serializer = new XmlSerializer(typeof(List<Phone>));
            using (var stream = File.OpenRead("phones.xml"))
            {
                List = (List<Phone>)serializer.Deserialize(stream);
            }
        }
    }
}
