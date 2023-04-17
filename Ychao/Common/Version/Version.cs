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
                ThrowHelper.ArgumentOutOfRangeException(ExceptionArgument.major);

            if (minor < 0)
                ThrowHelper.ArgumentOutOfRangeException(nameof(minor), SR.ArgumentOutOfRange_Version);

            if (build < 0)
                throw new ArgumentOutOfRangeException(nameof(build), SR.ArgumentOutOfRange_Version);

            if (revision < 0)
                throw new ArgumentOutOfRangeException(nameof(revision), SR.ArgumentOutOfRange_Version);

            _Major = major;
            _Minor = minor;
            _Build = build;
            _Revision = revision;
        }

        public object Clone()
        {

        }

        public int CompareTo(object obj)
        {
        }

        public bool Equals(Version other)
        {
            throw new NotImplementedException();
        }
    }
}
