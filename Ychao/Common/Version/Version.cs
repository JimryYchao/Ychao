using System;
using System.Diagnostics.CodeAnalysis;
using Ychao.Diagnostics;

namespace Ychao.Common
{
    public readonly struct Version : ICloneable, IComparable, IEquatable<Version>
    {
        private readonly int _Major;
        private readonly int _Minor;
        private readonly int _Build;
        private readonly int _Revision;

        public Version(int major, int minor, int build, int revision)
        {
            if (major < 0)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            if (minor < 0)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            if (build < 0)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            if (revision < 0)
                ThrowHelper.Exception(ExceptionType.ArgumentOutOfRangeException);

            _Major = major;
            _Minor = minor;
            _Build = build;
            _Revision = revision;
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            throw new Exception();
        }

        public bool Equals(Version other)
        {
            throw new NotImplementedException();
        }
    }
}
