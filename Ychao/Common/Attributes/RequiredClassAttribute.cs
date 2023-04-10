using System;
using System.Runtime.InteropServices;

namespace Ychao
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = true, Inherited = false)]
    [ComVisible(true)]
    public sealed class RequiredClassAttribute : Attribute
    {
        private Type[] requiredContracts;
        public Type[] RequiredContracts => requiredContracts;
        public RequiredClassAttribute(params Type[] requiredContracts)
        {
            this.requiredContracts = requiredContracts;
        }
    }


    //[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Delegate, Inherited = false)]
    //public sealed class ExternalVisibleAttribute : Attribute
    //{
    //    private bool visible;
    //    public bool Visible => visible;
    //    public ExternalVisibleAttribute(bool Visible)
    //    {
    //        this.visible = Visible;
    //    }
    //}


}
