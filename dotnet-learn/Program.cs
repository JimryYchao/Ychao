using dotnet_learn.SystemDiagnostics.Tests;
using System.Diagnostics.CodeAnalysis;
using System;
using System.Reflection;
using Ychao;
using System.Text;
using System.Buffers;

namespace dotnet_learn
{
    internal class Program
    {
        static void Main(string[] args)
        { }


        [DoesNotReturn]
        private void FailFast()
        {
            ThrowHelper.Exception("test");
        }

        public void SetState(object? containedField)
        {
            containedField = null;
            if (containedField is null)
            {
                FailFast();
            }

            // containedField can't be null:
        }
        private int FailFastIf([DoesNotReturnIf(true)] bool isNull)
        {
            if (isNull)
            {
                return 11;
                //throw new InvalidOperationException();
            }
            return 1;
        }

        public void SetFieldState([NotNull] object containedField)
        {
            FailFastIf(containedField == null);
            // No warning: containedField can't be null here:
        }
    }
}