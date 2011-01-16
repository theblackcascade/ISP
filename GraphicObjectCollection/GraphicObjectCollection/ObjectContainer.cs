using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GraphicObjectCollection
{
    [Serializable]
    public sealed class ObjectContainer: GraphicObject, IEnumerable<GraphicObject>, IDisposable
    {
        [Serializable]
        private class ObjectContainerEnumerator : IEnumerator<GraphicObject>
        {
            private int _currentDeepth = -1;

            public int MaxDeepth { get; private set; }
            private const int MaxContainerDeepth = 128;
            private readonly GraphicObject[] _list;

            public ObjectContainerEnumerator()
            {
                _list = new GraphicObject[MaxContainerDeepth];
            }

            public void Add(GraphicObject @object, int deepth)
            {
                if (GetItemsCount() > MaxContainerDeepth) throw new Exception("Container is Full");
                if (deepth > MaxDeepth) MaxDeepth = deepth;
                _list[deepth] = @object;
            }

            public void Delete(int deepth)
            {
                if (deepth < MaxContainerDeepth) _list[deepth] = null;
            }

            private int GetItemsCount()
            {
                return _list.Count();
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_currentDeepth < MaxDeepth)
                {
                    _currentDeepth++;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                _currentDeepth = -2;
            }

            public GraphicObject Current
            {
                get { return _list[_currentDeepth] ?? new GraphicObject(); }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        private readonly ObjectContainerEnumerator _enumerator = new ObjectContainerEnumerator();
        
        public ObjectContainer()
        {
            GlobalX = 666;
            GlobalY = 1488;
        }

        public void Add(GraphicObject @object, int deepth)
        {
            if (@object == null) throw new ArgumentNullException("object");
            @object.Container = this;
            _enumerator.Add(@object,deepth);
        }

        public void Add(GraphicObject @object)
        {
            if (@object == null) throw new ArgumentNullException("object");
            @object.Container = this;
           _enumerator.Add(@object,_enumerator.MaxDeepth);
        }
        public void Delete(int deepth)
        {
            _enumerator.Delete(deepth);
        }

        public IEnumerator<GraphicObject> GetEnumerator()
        {
            return _enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public new void Move(int x, int y)
        {
            foreach (var o in this)
            {
                o.Move(o.GlobalX+x,o.GlobalY+y);
            }
        }

        public void Rotate(double angle)
        {
            throw new NotImplementedException();
        }
        
        public new void Draw() 
        {
            foreach (var o in this)
            {
                o.Draw();
            }
        }

        public new byte[] ToByte()
        {
            var array = new byte[2047];
            foreach (var o in this)
            {
                array.Concat(o.ToByte());
            }
            return array;
        }
        
        public new string ToString()
        {
            return this.GetEnumerator().ToString();
        }

        public void Dispose()
        {
            _enumerator.Dispose();
        }

        public XStreamingElement ToXml()
        {
            return new XStreamingElement("objectContainer", 
                                 from o in this select new XStreamingElement("graphicObject",
                                                               new XStreamingElement("GlobalX", o.GlobalX),
                                                               new XStreamingElement("GlobalY", o.GlobalY),
                                                               new XStreamingElement("ZBuffer", o.ZBuffer),
                                                               new XStreamingElement("IsParals", o.IsParalax),
                                                               new XStreamingElement("Rotation", o.RotationAngle)));

        }
    }

    
}
