using System;
using System.Collections.Generic;
using System.Linq;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class LambdaTests
    {
        [Test]
        public void Simple()
        {
            var compiler = new FormulaCompiler().WithSystem();

            var f = compiler.Compile<Func<string, int, int>>("(string x, int y) => 5 + x.Length + y");
            f.ShouldNotBeNull();

            f()("abc", 2).ShouldEqual(10);
        }

        [Test]
        public void Where()
        {
            var compiler = new FormulaCompiler().WithLinq();

            var f = compiler.NewLambda()
                .WithParam<IEnumerable<int>>("data")
                .Returns<double>()
                .Compile("data.Where((int e)=> e < 5).Where((int x)=>x>2).Average()");

            f.ShouldNotBeNull();
            f(Enumerable.Range(0, 10)).ShouldEqual(3.5d);
        }
    }
}