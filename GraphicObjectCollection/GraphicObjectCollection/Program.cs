using System;

namespace GraphicObjectCollection
{
    class Program
    {   
        static void Main(string[] args)
        {
            var s = new StateManager("test");
            var o = new GraphicObject();
            var o1 = new GraphicObject();
            var o2 = new GraphicObject {Container = null,GlobalX = 10,GlobalY = 1000};
            var c = new ObjectContainer {o, o1, o2 };
            s.Serialize(c);
            s.XmlSerialization(o);
            s.DataContractSerialization(o2);
            var c2 = s.XmlDeserialization();
            var c3 = s.Deserialize();
            var j = s.DataContractDeserialization();
            s.ObjectContainerSaveState(c);
            s.ObjectContainerTextSaveState(c);
            Console.WriteLine("{0},{1},{2}",c2.ToString(),c3.ToXml(),j.ToString());
            Console.ReadKey();
        }
    }
}
