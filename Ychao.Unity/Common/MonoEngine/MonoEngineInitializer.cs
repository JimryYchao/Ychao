using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ychao.Unity.Common.MonoEngine
{
    internal class MonoEngineInitializer : IInitialize
    {
        private bool _inited = false;
        public bool IsInited => _inited;

        public void Initialize()
        {



            _inited = true;
        }
    }
}
