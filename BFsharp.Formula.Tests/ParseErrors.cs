using System;
using System.Diagnostics;
using System.Linq;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture, Ignore]
    public class ParseErrors
    {
        // TODO: move to base
        readonly FormulaCompiler _compiler = new FormulaCompiler();

        private void Compile(string formula, params int[] expectedErrorNumbers)
        {
            
                _compiler.Compile<int>(formula);
            //}
            //catch (ParseException e)
            //{
            //    Debug.WriteLine(e.Message);
            //    foreach (var errorNumber in expectedErrorNumbers)
            //    {
            //        if ( e.Errors.Where(err=>err.Number == errorNumber).FirstOrDefault() == null)
            //            Assert.Fail("Error {0} not thrown.", errorNumber);
            //    }
            //}
        }

        [Test]
        public void UnclosedBracket()
        {
            Compile(@"(5 + 5", 139);
        }

        [Test]
        public void MissingExpression()
        {
            Compile(@"(5 +)", 239);
        }

        [Test]
        public void A()
        {
            _compiler.Compile<int>(@"abc(aaa, )+");
        }
        
        [Test]
        public void B()
        {
            _compiler.Compile<int>(@"(1+2)))");
        }

        [Test]
        public void Test()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"5 + 5 {}");
            f().ShouldEqual(10);
        }

        [Test]
        public void Test2()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"55 # + 5;");
            f().ShouldEqual(60);
        }

        [Test]
        public void Test3()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"55 # + 5");
            f().ShouldEqual(60);
        }

        [Test]
        public void Test5()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"5 {5}");
            f().ShouldEqual(5);
        }

        [Test]
        public void Test4()
        {
            var compiler = new FormulaCompiler();
            var f = compiler.Compile<int>(@"55 + 5;");
            f().ShouldEqual(60);
        }
    }
}