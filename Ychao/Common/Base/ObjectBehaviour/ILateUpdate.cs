using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public interface ILateUpdate
    {
        void OnLateUpdate();
    }

    public delegate void OnLateUpdate(ILateUpdate lateUpdate);
    public delegate void OnLateUpdateBefore(ILateUpdate lateUpdate);
    public delegate void OnLateUpdateCompleted(ILateUpdate lateUpdate);
}
