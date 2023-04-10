using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychao.Collections
{
    internal sealed class IDynaEnumerationDebugView<T>
    {
        private readonly IDynaEnumeration<T> _enumeration;

        public IDynaEnumerationDebugView(IDynaEnumeration<T> enumeration)
        {
            if (enumeration == null)
                ThrowHelper.ArgumentNull(nameof(enumeration));
            _enumeration = enumeration;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] items
        {
            get
            {
                T[] items = new T[_enumeration.Count];
                _enumeration.CopyTo(items, 0);
                return items;
            }
        }

    }
}
