using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using System.IO;

namespace GraphicObjectCollection
{
    class StateManager
    {
        private readonly byte[] _buffer = new byte[2048];
        private readonly FileInfo _file;
        private readonly FileStream _fs;

        public StateManager(string fileName)
        {
            _file = fileName != null ? new FileInfo(fileName) : new FileInfo(@"C:\Temp.x");
            _fs = _file.Open(FileMode.OpenOrCreate,FileAccess.ReadWrite, FileShare.None);
        }

        public void ObjectContainerSaveState(ObjectContainer o)
        {
            using (var stream = File.Create("x.ssa"))
            {
                stream.Write(_buffer, 0, 0);
            }
        }

        public void ObjectContainerTextSaveState(ObjectContainer o)
        {
            TextWriter.Null.Write(o.ToString());
        }

        public string LoadState()
        {
            using (var stream = File.OpenRead("x.ssa"))
            {
                return stream.Read(_buffer, 0, 0).ToString();
            }
        }

        public void Serialize(ObjectContainer o)
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.Create("x.dat"))
            {
                formatter.Serialize(stream, o);
            }
        }
        public ObjectContainer Deserialize()
        {
            var formatter = new BinaryFormatter();
            using (var stream = File.OpenRead("x.dat"))
            {
                return (ObjectContainer) formatter.Deserialize(stream);
            }
        }
        public void XmlSerialization(GraphicObject o)
        {
            var serializer = new XmlSerializer(typeof(GraphicObject));
            using (var stream = File.Create("x.xml"))
            {
                serializer.Serialize(stream,o);
            }
        }
        public GraphicObject XmlDeserialization()
        {
            var serializer = new XmlSerializer(typeof(GraphicObject));
            using (var stream = File.OpenRead("x.xml"))
            {
                return (GraphicObject) serializer.Deserialize(stream);
            }
 
        }
        public void DataContractSerialization(GraphicObject o)
        {
            var serializer = new DataContractJsonSerializer(typeof (GraphicObject));
            using (var stream = File.Create("x.json"))
            {
                serializer.WriteObject(stream, o);
            }
        }
        public GraphicObject DataContractDeserialization()
        {
            var serializer = new DataContractJsonSerializer(typeof(GraphicObject));
            using (var stream = File.OpenRead("x.json"))
            {
                return (GraphicObject)serializer.ReadObject(stream);
            }
        }
    }
}
