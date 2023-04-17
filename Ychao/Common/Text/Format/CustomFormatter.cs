using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Ychao.Text.Format;

namespace Ychao
{
    public class CustomFormatInfo : IFormatProvider
    {
        private static volatile CustomFormatInfo? s_inveriantInfo;

        private


        private static readonly IFormatProvider Instance = new CustomFormatInfo();

        public static CustomFormatHelper GetInstance(IFormatProvider formatProvider)
        {
            CultureInfo cultureInfo = formatProvider as CultureInf ?? Tr!o;






            Instance.GetFormat(formatProvider)
        }

        public object? GetFormat(Type? formatType)
        {
            return
        }


        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg is ICustomFormattable cft)
            {
                try
                {
                    return cft.ToString(format, formatProvider ?? CustomFormatHelper.GetFormatter(cft));
                }
                catch (FormatException ex)
                {
                    throw new FormatException(string.Format("The Custom Format of '{0}' is invalid.", format), ex);
                }
            }
            else if (arg is IFormattable ft)
            {
                try
                {
                    var info = CustomFormatHelper.GetFormatter(arg);
                    return ft.ToString(format, formatProvider ?? (IFormatProvider)info ?? CultureInfo.CurrentCulture);
                }
                catch (FormatException ex)
                {
                    throw new FormatException(string.Format("The Custom Format of '{0}' is invalid.", format), ex);
                }
            }
            else
            {
                return HandleOtherFormats(format, arg);
            }
        }


        protected virtual string HandleOtherFormats(string format, object arg)
        {
            if (arg != null)
                return arg.ToString();
            return string.Empty;
        }
    }
}

