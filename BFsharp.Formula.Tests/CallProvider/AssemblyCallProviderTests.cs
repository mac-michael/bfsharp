using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class AssemblyCallProviderTests
    {
        [Test]
        public void Test()
        {
            var p = new AssemblyCallProvider()
                .AddAssembly("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                .AddAssembly("System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                .Using("System", "System.Linq");

            var m = p.FindMethod(null, "Enumerable.Repeat", new[] {typeof (int), typeof (int)});
            m.ShouldNotBeNull();
        }

        [Test]
        public void ExtensionMethods()
        {
            var p = new AssemblyCallProvider()
                .AddAssembly("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                .AddAssembly("System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
                .Using("System", "System.Linq")
                .WithExtensionMethods();

            var m = p.FindMethod(typeof(IEnumerable<int>), "Max", new Type[0]);
            m.ShouldNotBeNull();
        }

    }
}