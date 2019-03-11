using System;
using System.Collections;

namespace IEnumerableVsIEnumerator
{
    class Program
    {
        static void Main(string[] args)
        {

            List list = new List();
            list.Add("This");
            list.Add("is ");
            list.Add("Demo ");
            list.Add("for");
            list.Add("IEnumerable Vs IEnumerator");
            


            var enumerator = list.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }


            foreach (var e in list) { Console.WriteLine(e); }
        }
    }

    public class List:IEnumerable
    {

        private object[] _objects;
        int index;
        public List()
        {
            index = -1;
            _objects = new object[100];
        }

        public void Add(object obj)
        {
           
            _objects[++index] = obj;
        }

        public IEnumerator GetEnumerator()
        {
            return new ListEnumerator(this);
        }


        //nested class
        private class ListEnumerator : IEnumerator
        {
            private int _currentIndex = -1;
            private List _l;

            public ListEnumerator(List l)
            {
                _l = l;
            }
            public object Current
            {
                get
                {
                    try
                    {
                        return _l._objects[_currentIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {

                        throw new InvalidOperationException();
                    }

                }
            }
            public bool MoveNext()
            {
                   _currentIndex++;
                return _currentIndex<=_l.index;
            }
            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }
}
