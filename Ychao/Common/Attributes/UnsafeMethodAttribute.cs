using System;

namespace Ychao
{
    /// <summary>
    /// 待拓展
    /// </summary>
    public class UnsafeMethodAttribute : Attribute
    {
        public UnsafeMethodAttribute()
        {
            _message = "THIS Method is not safe";
        }

        public UnsafeMethodAttribute(string message)
        {
            _message = message;
        }

        private string _message;
        public string Message => _message;
    }
}
