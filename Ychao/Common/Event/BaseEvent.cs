using System.Reflection;

namespace Ychao.EventMenagement
{
    public abstract partial class BaseEvent : IEventCallback
    {




        
    }


    class RuntimeCallEventList
    {
        //private readonly List<>


    }



    internal abstract class BaseEventCallable
    {
        protected BaseEventCallable() { }
        protected BaseEventCallable(object target, MethodInfo function)
        {
            //if (function == null)
            //    throw new ArgumentNull();
        }
        public abstract void Invoke(object[] args);




    }
}
