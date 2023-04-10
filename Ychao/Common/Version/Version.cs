﻿using System;
using Ychao.Common.Diagnostics.Debug;

namespace Ychao.Common
{
    public readonly struct Version : ICloneable, IComparable, IEquatable<Version?>
    {
        private readonly int _Major;
        private readonly int _Minor;
        private readonly int _Build;
        private readonly int _Revision;

        public Version(int major, int minor, int build, int revision)
        {
            Assert.Diagnostic(major < 0, ThrowHelper.ArgumentOutOfRange("major", ))

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

        public bool Equals(Version? other)
        {
        }
    }
}