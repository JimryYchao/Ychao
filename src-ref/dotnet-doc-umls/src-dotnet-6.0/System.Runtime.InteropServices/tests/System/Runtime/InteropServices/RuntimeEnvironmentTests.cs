// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.IO;
using Xunit;

namespace System.Runtime.InteropServices
{
    public class RuntimeEnvironmentTests
    {
        [Fact]
        public void RuntimeEnvironmentRuntimeDirectory()
        {
            Assert.True(Directory.Exists(RuntimeEnvironment.GetRuntimeDirectory()));
        }

        [Fact]
        public void RuntimeEnvironmentSysVersion()
        {            
            Assert.NotEmpty(RuntimeEnvironment.GetSystemVersion());
        }

        [Fact]
        public void SystemConfigurationFile_Get_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(() => RuntimeEnvironment.SystemConfigurationFile);
        }

        [Fact]
        public void GetRuntimeInterfaceAsObject_Invoke_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(() => RuntimeEnvironment.GetRuntimeInterfaceAsObject(Guid.Empty, Guid.Empty));
        }

        [Fact]
        public void GetRuntimeInterfaceAsIntPtr_Invoke_ThrowsPlatformNotSupportedException()
        {
            Assert.Throws<PlatformNotSupportedException>(() => RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(Guid.Empty, Guid.Empty));
        }

        [Fact]
        public void FromGlobalAccessCache_nNvoke_ReturnsFalse()
        {
            Assert.False(RuntimeEnvironment.FromGlobalAccessCache(typeof(RuntimeEnvironmentTests).Assembly));
            Assert.False(RuntimeEnvironment.FromGlobalAccessCache(null));
        }
    }
}