using System;

namespace Ychao.Text.Format
{
    public interface ICustomFormattable : IFormattable
    {
        string ToString(string format, ICustomFormatProvider? formatProvider);
    }
}
