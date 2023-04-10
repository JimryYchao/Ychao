using System.Collections;
using System.Collections.Generic;

namespace Ychao.Collections
{
    public interface IDynamicEnumerable : IEnumerable
    {

    }

    public interface IDynamicEnumerator : IEnumerator
    {

    }

    public interface IDynamicEnumerable<T> : IDynamicEnumerable, IEnumerable<T>
    {

    }

    public interface IDynamicEnumerator<T> : IEnumerator<T>, IDynamicEnumerable
    {

    }

    public interface IDynaEnumeration : IDynamicEnumerable
    {
        int Count { get; }
        void Add(object item);
        void Clear();
        bool Contains(object item);
        void CopyTo(object[] array, int arrayIndex);
        bool Remove(object item);
        int IndexOf(object item);
        void Insert(int index, object item);
        void RemoveAt(int index);
    }

    public interface IDynaEnumeration<T> : IDynamicEnumerable<T>
    {
        int Count { get; }
        bool IsReadOnly { get; }
        void Add(T item);
        void Clear();
        void Contains(T item);
        void CopyTo(T[] array, int arrayIndex);
        bool Remove(T item);
        int IndexOf(T item);
        void Insert(int index, T item);
        void RemoveAt(int index);
    }
}
