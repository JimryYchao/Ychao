using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public interface IActive
    {
        void OnAwake();
    }

    public delegate void OnActive(IActive awake);
    public delegate void OnActiveBefore(IActive awake);
    public delegate void OnActiveCompleted(IActive awake);
}
