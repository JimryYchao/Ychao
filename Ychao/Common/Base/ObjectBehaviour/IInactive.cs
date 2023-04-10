using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    public interface IInactive
    {
        void OnInactive();
    }


    public delegate void OnInactive(IInactive inactive);
    public delegate void OnInactiveBefore(IInactive inactive);
    public delegate void OnInactiveCompleted(IInactive inactive);
}
