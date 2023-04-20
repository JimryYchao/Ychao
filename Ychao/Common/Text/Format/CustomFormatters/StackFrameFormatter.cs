using System;
using System.Diagnostics;
using System.Globalization;

namespace Ychao.Text.Format
{
    public partial class StackFrameCustomFormatter : ICustomFormatProvider
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() == typeof(StackFrame))
            {
                string fmt = format.ToUpper(CultureInfo.InvariantCulture);






            }
            else
            {
            }
            return null;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(StackFrame))
                return this;
            else return null;
        }

        protected IFormatProvider GetFormatProvider(object arg)
        {
            throw new NotImplementedException();
        }



    }
}

