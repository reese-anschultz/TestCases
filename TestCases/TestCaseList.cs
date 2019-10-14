using System.Collections;
using System.Collections.Generic;

namespace TestCases
{
    // Making our own list so that unwanted properties of List (in particular
    // Capacity) don't get serialized and de-serialized.
    public class TestCaseList<T> : IList<T>
    {
        private readonly List<T> _list;

        protected TestCaseList() => _list = new List<T>();

        protected TestCaseList(IEnumerable<T> collection) => _list = new List<T>(collection);

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public int Count => _list.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_list).IsReadOnly;

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }
    }
}
