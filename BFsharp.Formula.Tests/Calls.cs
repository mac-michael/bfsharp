using System;
using System.Linq;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class Calls
    {
        private FormulaCompiler _compiler;

        [TestFixtureSetUp]
        public void Init()
        {
            _compiler = new FormulaCompiler()
                .WithMath()
                .WithDate()
                .WithType<This>()
                .WithType<string>();
        }

        [Test]
        public void RootCallMethodTest()
        {
            var f = _compiler.Compile<int>("abs(-5)");

            f().ShouldEqual(Math.Abs(-5));
        }

        [Test]
        public void MaxMethodTest()
        {
            var f = _compiler.Compile<int>("max(1,6)");

            f().ShouldEqual(6);
        }

        [Test]
        public void RootCallPropertyTest()
        {
            var f = _compiler.Compile<DateTime>("Today");

            DateTime now = DateTime.Now;
            f().ShouldEqual(new DateTime(now.Year, now.Month, now.Day));
        }

        [Test]
        public void RootCallThisPropertyTest()
        {
            var param = new This { CurrentUserProperty = "michael" };
            var f = _compiler.NewLambda()
                .WithThis<This>()
                .Returns<string>()
                .Compile("CurrentUserProperty");
            f(param).ShouldEqual("michael");
        }

        [Test]
        public void RootCallThisMethodTest()
        {
            var param = new This();
            var f = _compiler.NewLambda()
                .WithThis<This>()
                .Returns<string>()
                .Compile("CurrentUser");
            f(param).ShouldEqual("user");
        }

        [Test]
        //[ExpectedException(typeof(MethodNotFoundException))]
        public void RootCallThisMethodWithoutParamTest()
        {
            _compiler.NewLambda()
                .Returns<string>()
                .Compile("CurrentUser");

            _compiler.BuildInfo.Errors.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void TypeCallTest()
        {
            var param = new This{CurrentUserProperty="michael"};
            var f = _compiler.NewLambda()
                .WithThis<This>()
                .Returns<int>()
                .Compile("CurrentUserProperty.Length");
            f(param).ShouldEqual(7);
        }

        [Test]
        //[ExpectedException(typeof(MethodNotFoundException))]
        public void TypeCallNoneExistingTest()
        {
            _compiler.NewLambda()
                .WithThis<This>()
                .Returns<int>()
                .Compile("CurrentUserProperty.NonExistingMethod()");
            
            _compiler.BuildInfo.Errors.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        public void CompoundTest()
        {
            var param = new This { CurrentUserProperty = "michael" };
            var f = _compiler.NewLambda()
                .WithThis<This>()
                .Returns<int>()
                .Compile("CurrentUserProperty.Length()+2*2");
            f(param).ShouldEqual(11);
        }

        [Test]
        public void FlatTypeProviderTest()
        {
            var compiler = new FormulaCompiler()
                .WithFlatType(typeof(Math));

            var f = compiler.Compile<int>("max(4,2)");
            f().ShouldEqual(4);
        }

        [Test]
        public void ParamTest()
        {
            var compiler = new FormulaCompiler();

            var f = compiler.NewLambda().
                WithParam<int>("Param1").
                WithParam<int>("Param2").
                Returns<int>().
                Compile("Param1 * Param2");

            f(2, 3).ShouldEqual(6);
        }

        [Test]
        //[ExpectedException(typeof(ParameterNotFoundException))]
        public void NonExistingParam()
        {
            var compiler = new FormulaCompiler();

            compiler.NewLambda()
                .Returns<int>()
                .Compile("@Param");

            compiler.BuildInfo.Errors.Count().ShouldBeGreaterThan(0);
        }

        [Test]
        //[ExpectedException(typeof(MethodNotFoundException))]
        public void SecondLevelParam()
        {
            var compiler = new FormulaCompiler();

            compiler.NewLambda()
                .WithParam<int>("Param")
                .Returns<int>()
                .Compile("@Param.@abc");

            compiler.BuildInfo.Errors.Count().ShouldBeGreaterThan(0);
        }
    }
}