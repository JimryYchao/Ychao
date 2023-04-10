using System;
using System.Collections;
using System.Diagnostics;
using Ychao.Common.Diagnostics.ExceptionCapture.Ref;

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
            Assert.Diagnostic(capacity < 0, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.capacity));

            if (capacity == 0)
                _items = s_emptyArray;
            else
                _items = new object[capacity];
        }

        public DynaEnumeration(IEnumerable collection)
        {
            Assert.Diagnostic(collection == null, ThrowHelper.ArgumentNull(ExceptionArgument.collection));


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
                Assert.Diagnostic(value < _size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.value, "Small Capacity"));

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
                Assert.Diagnostic((uint)index >= (uint)_size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));
                return _items[index];
            }

            set
            {
                Assert.Diagnostic((uint)index >= (uint)_size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

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
            Assert.Diagnostic((uint)index > (uint)_size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

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
            Assert.Diagnostic(collection == null, ThrowHelper.ArgumentNull(ExceptionArgument.collection));

            Assert.Diagnostic((uint)index > (uint)_size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

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
            Assert.Diagnostic((uint)index >= (uint)_size, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

            _size--;
            if (index < _size)
                Array.Copy(_items, index + 1, _items, index, _size - index);
            _items[_size] = default!;  // 若引用类型则 null，或为类型默认值

            _version++;
        }
        public void RemoveRange(int index, int count)
        {
            Assert.Diagnostic(index < 0, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

            Assert.Diagnostic(count < 0, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.count));

            Assert.Diagnostic(_size - index < count, ThrowHelper.Argument(ExceptionArgumentResource.Invalid_Of_Length));

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
            Assert.Diagnostic(index < 0, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.index));

            Assert.Diagnostic(count < 0, ThrowHelper.ArgumentOutOfRange(ExceptionArgument.count));

            Assert.Diagnostic(_size - index < count, ThrowHelper.Argument(ExceptionArgumentResource.Invalid_Of_Length));

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
