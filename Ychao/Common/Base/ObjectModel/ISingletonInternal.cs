using System;
using System.Collections.Generic;
using System.Text;

namespace Ychao
{
    internal interface ISingletonInternal<T> : ISingleton<T> where T : class, ISingleton<T> { }
}
