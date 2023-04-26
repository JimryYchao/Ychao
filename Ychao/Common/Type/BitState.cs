using System;
using System.Buffers.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ychao
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct BitState : IEquatable<BitState>, IEnumerable<bool>
    {
        //struct BitView
        //{

        //}

        private volatile uint m_bits;
        public const int MaxSize = sizeof(uint);
        public const int MinSize = 1;
        public const int DefaultSize = 16;

        public readonly static object s_locker = new object();
        public readonly int size;

        public override string ToString()
        {
            return Convert.ToString(m_bits & ((1 << size) - 1), 2).PadLeft(size, '0');
        }

        public BitState(ushort size)
        {
            this.size = size > 0 && size <= MaxSize ? size : DefaultSize;
            m_bits = 0;
        }

        public BitState(uint bit, int size)
        {
            this.m_bits = bit;
            this.size = size;
        }

        public bool this[int i]
        {
            get
            {
                CheckIndex(i);
                return ((i << i) & m_bits) > 0;
            }

            set
            {
                CheckIndex(i);
                if (value)
                    Open((uint)1 << i);
                else
                    Close((uint)1 << i);
            }
        }

        uint MaskNormalize(IEnumerable<int> bits)
        {
            uint mask = 0;
            foreach (var item in bits)
            {
                CheckIndex(item);
                mask |= ((uint)1 << item);
            }
            Console.WriteLine(Convert.ToString(mask, 2).PadLeft(size, '0'));
            return mask;
        }
        void CheckIndex(int i)
        {
            if (i < 0 || i >= size)
                throw new IndexOutOfRangeException();
        }

        public void Clear()
        {
            m_bits = 0;
        }

        public void Mask(uint state)
        {
            lock (s_locker)
                m_bits &= state;
        }
        public void Mask(IEnumerable<int> bits)
        {
            lock (s_locker)
                m_bits &= MaskNormalize(bits);
        }

        public bool Check(int index)
        {
            return this[index];
        }

        public void SwitchAll()
        {
            m_bits = ~m_bits;
        }

        public void Inverse(IEnumerable<int> bits)
        {
            lock (s_locker)
            {
                foreach (var i in bits)
                {
                    CheckIndex(i);
                    this[i] = !this[i];
                }
            }
        }

        public void Open(uint state)
        {
            m_bits |= state;
        }

        public void Open(IEnumerable<int> bits)
        {
            lock (s_locker)
                m_bits |= MaskNormalize(bits);
        }

        public void Close(uint state)
        {
            m_bits &= ~state;
        }

        public void Close(IEnumerable<int> bits)
        {
            lock (s_locker)
                m_bits &= ~MaskNormalize(bits);
        }

        public void Switch(uint state)
        {
            m_bits ^= state;
        }

        public void Switch(IEnumerable<int> bits)
        {
            m_bits ^= MaskNormalize(bits);
        }

        public bool Equals(BitState other)
        {
            if (size != other.size)
                return false;
            var mask = uint.MaxValue << size;
            return (m_bits | mask) == (other.m_bits | mask);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<bool> GetEnumerator()
        {
            return new BitEnunerator(this);
        }


        public static implicit operator bool[](BitState bit)
        {
            bool[] bits = new bool[bit.size];
            lock (s_locker)
                for (int i = 0; i < bit.size; i++)
                    bits[i] = bit[i];

            return bits;
        }

        struct BitEnunerator : IEnumerator<bool>
        {
            private bool current;
            public bool Current => current;

            BitState bitGroup;
            int i;

            public BitEnunerator(BitState bit)
            {
                this.current = false;
                this.bitGroup = bit;
                i = 0;
            }
            object IEnumerator.Current => Current;

            void IDisposable.Dispose()
            {
            }

            public bool MoveNext()
            {
                if (i >= bitGroup.size)
                    return false;
                current = bitGroup[i];
                i++;
                return true;
            }

            void IEnumerator.Reset()
            {
            }
        }
    }
}