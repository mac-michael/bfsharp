using System.Collections.Generic;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class PerformanceTests
    {
        [Test]
        public void Simple()
        {
            var compiler = new FormulaCompiler()
                .WithInfo(FormulaCompilerBuildInfoLevels.None);
            compiler.Compile<int>("5+4");

            TestTime.Measure(1000, () => compiler.Compile<int>("5+4"));
        }

        [Test]
        public void Complex()
        {
            var compiler = new FormulaCompiler()
                .WithMath().WithInfo(FormulaCompilerBuildInfoLevels.None);

            TestTime.Measure(1000, () => compiler.Compile<int>("2+2*2 + max(4,5)"));
        }

        [Test]
        public void ProcessorCount()
        {
            var compiler = new FormulaCompiler()
                .WithInfo(FormulaCompilerBuildInfoLevels.None)
                .WithSystem();

            TestTime.Measure(1000, () => compiler.Compile<int>("Environment.ProcessorCount"));
        }

        [Test]
        public void Linq()
        {
            var compiler = new FormulaCompiler()
                .WithInfo(FormulaCompilerBuildInfoLevels.None)
                .WithLinq();
            var lambda = compiler.NewLambda()
                .WithParam<IEnumerable<int>>("input")
                .Returns<int>();

            TestTime.Measure(1000, () => lambda.Compile("input.Max()"));
        }
    }
}