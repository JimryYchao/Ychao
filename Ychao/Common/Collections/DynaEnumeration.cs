using System;
using System.Collections;
using System.Diagnostics;
using Ychao;

namespace Ychao.Collections
{
    /// <summary>
    /// 在枚举时可动态的调整大小，但已经枚举过的对象在更新状态后在此次枚举过程未完成时不会再次调用
    /// </summary>
    [DebuggerTypeProxy(typeof(IDynaEnumerationDebugView<object>))]
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public sealed class DynaEnumeration : IDynaEnumeration
    {
        private const int _defaultCapacity = 4;
        private int _size;
        private int _version;
        private object[] _items;

        private static readonly object[] s_emptyArray = new object[0];

        public DynaEnumeration()
        {
            _items = s_emptyArray;
        }

        public DynaEnumeration(int capacity)
        {
            if (capacity <= 0)
                _items = s_emptyArray;
            else
                _items = new object[capacity];
        }

        public DynaEnumeration(IEnumerable collection)
        {
            if (collection == null)
                ThrowHelper.Exception(ExceptionType.ArgumentNullException);


            if (collection is ICollection c)
            {
                int count = c.Count;
                if (count == 0)
                    _items = s_emptyArray;

                else
                {
                    _items = new object[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else if (collection is IDynaEnumeration dc)
            {
                int count = dc.Count;
                if (count == 0)
                    _items = s_emptyArray;

                else
                {
                    _items = new object[count];
                    dc.CopyTo(_items, 0);
                    _size = count;
                }
            }
            else
            {
                _size = 0;
                _items = s_emptyArray;
                IEnumerator en = collection.GetEnumerator();

                while (en.MoveNext())
                    Add(en.Current);
            }
        }
        public int Capacity
        {
            get => _items.Length;
            set
            {
                if (value < _size)
                    ThrowHelper.Exception("Small Capacity");

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        object[] newItems = new object[value];

                        if (_size > 0)
                            Array.Copy(_items, 0, newItems, 0, _size);
                        _items = newItems;
                    }
                    else _items = s_emptyArray;
                }

            }
        }
        public int Count => _size;

        public object this[int index]
        {
            get
            {
                if (index >= _size || index < 0)
                    ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);
                return _items[index];
            }

            set
            {
                if (index >= _size || index < 0)
                    ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);

                _items[index] = value;
                _version++;
            }
        }

        public void Add(object item)
        {
            _version++;
            object[] array = _items;
            int size = _size;

            if ((uint)size < (uint)array.Length)
            {
                _size = size + 1;
                array[size] = item;
            }
            else
                AddWithResize(item);
        }
        public void Insert(int index, object item)
        {
            if (index >= _size || index < 0)
                ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);

            if (_size == _items.Length)
                EnsureCapacity(_size + 1);

            if (index < _size)
                Array.Copy(_items, index, _items, index + 1, _size - index);

            _items[index] = item;
            _size++;
            _version++;
        }
        public void AddRange(IEnumerable collection)
        {
            InsertRange(_size, collection);
        }
        public void InsertRange(int index, IEnumerable collection)
        {
            if (collection == null) ThrowHelper.Exception(ExceptionType.ArgumentNullException);
            if ((uint)index >= (uint)_size)
                ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);

            if (collection is ICollection c)
            {
                int count = c.Count;
                if (count > 0)
                {
                    EnsureCapacity(_size + count);
                    if (index < _size)
                        Array.Copy(_items, index, _items, index + count, _size - index);
                    c.CopyTo(_items, index);
                }
                _size += count;
            }
        }

        public int IndexOf(object item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public bool Contains(object item)
        {
            return _size != 0 && IndexOf(item) != -1;
        }

        public bool Remove(object item)
        {
            int i = IndexOf(item);
            if (i >= 0)
            {
                RemoveAt(i);
                return true;
            }
            return false;

        }
        public void RemoveAt(int index)
        {
            if (index >= _size || index < 0)
                ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);

            _size--;
            if (index < _size)
                Array.Copy(_items, index + 1, _items, index, _size - index);
            _items[_size] = default!;  // 若引用类型则 null，或为类型默认值

            _version++;
        }
        public void RemoveRange(int index, int count)
        {
            if (index < 0 || index >= _size)
                ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);
            if (count < 0 || _size - index < count)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            if (count > 0)
            {
                _size -= count;
                if (index < _size)
                    Array.Copy(_items, index + count, _items, index, _size - index);

                _version++;

                Array.Clear(_items, _size, count);
            }

        }
        public void Clear()
        {
            _version++;

            // 由于是引用类型，需要调用 Array.Clear 清除元素，便于 GC 回收
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
        }


        public void CopyTo(object[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }
        public void Sort(int index, int count, IComparer comparer)
        {
            if (index < 0 || index >= _size)
                ThrowHelper.Exception(ExceptionType.IndexOutOfRangeException);

            if (count < 0 || _size - index < count)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            if (count > 1)
                Array.Sort(_items, index, count, comparer);

            _version++;
        }

        private void AddWithResize(object item)
        {
            int size = _size;
            EnsureCapacity(size + 1);
            _size = size + 1;
            _items[size] = item;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > CollectionHelper.MaxArrayLength)
                    newCapacity = CollectionHelper.MaxArrayLength;
                if (newCapacity < min)
                    newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new DynaEnumerator(this);
        }

        class DynaEnumerator : IDynamicEnumerator
        {
            internal DynaEnumerator(DynaEnumeration enumeration)
            {
                this.BindsEnumeration = enumeration;
                _curIndex = 0;
                _version = BindsEnumeration._version;
                _current = default!;
            }

            private int _currentHashCode;
            private DynaEnumeration BindsEnumeration;
            private int _curIndex;
            private int _version;

            // 枚举过程中可能会出现删减的情况，需要定位当前锁定的对象的位置


            private object _current;


            public object Current => _current;

            public bool MoveNext()
            {
                if (_version == BindsEnumeration._version && ((uint)_curIndex < (uint)BindsEnumeration._size))
                {
                    _current = BindsEnumeration._items[_curIndex];
                    _curIndex++;
                    _currentHashCode = _current.GetHashCode();
                    return true;
                }
                else
                {
                    _version = BindsEnumeration._version;
                    if ((uint)_curIndex < (uint)BindsEnumeration._size)
                    {
                        _current = BindsEnumeration._items[_curIndex];
                        _curIndex++;
                        return true;
                    }
                    else return false;
                }
            }

            void IEnumerator.Reset()
            {
                if (_version != BindsEnumeration._version)
                {
                    _version = BindsEnumeration._version;
                }
                _curIndex = 0;
                _current = default!;

            }
        }


    }
}
