using System.Diagnostics;

namespace Ychao.Collections
{
    internal sealed class IDynaEnumerationDebugView<T>
    {
        private readonly IDynaEnumeration<T> _enumeration;

        public IDynaEnumerationDebugView(IDynaEnumeration<T> enumeration)
        {
            if (enumeration == null)
                ThrowHelper.Exception(ExceptionType.ArgumentNullException);
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
