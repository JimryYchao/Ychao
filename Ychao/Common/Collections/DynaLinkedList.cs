using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychao.Collections
{

    [Serializable]
    [DebuggerTypeProxy(typeof(IDynaEnumerationDebugView<>))]
    [DebuggerDisplay("Conut = {Count}")]
    public class DynaLinkedList<T>
    {







    }


    public sealed class DynaLinkedList : DynaLinkedList<object>
    {

    }

}
