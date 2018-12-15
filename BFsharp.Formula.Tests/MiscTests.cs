using System;
using System.Diagnostics;
using System.Linq;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void Multiline()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"5 +
4 + 2
-2");
            f().ShouldEqual(9);
        }

        [Test]
        public void PerformanceTest()
        {
            var compiler = new FormulaCompiler();
            compiler.WithInfo( FormulaCompilerBuildInfoLevels.Warning);
            var s = Stopwatch.StartNew();

            for (int i = 0; i < 1e4; i++)
            {
                var f = compiler.Compile<int>("2*5");
            }
            s.Stop();
            Debug.WriteLine("Compile time: " + s.Elapsed);
            
            var func = compiler.Compile<int>("2*5");
            s = Stopwatch.StartNew();

            for (int i = 0; i < 1e6; i++)
            {
                var res = func();
            }
            s.Stop();
            Debug.WriteLine("Compile time: " + s.Elapsed);

        }
    }
}