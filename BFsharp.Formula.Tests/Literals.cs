using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class Literals
    {
        private readonly FormulaCompiler _compiler = new FormulaCompiler();

        [Test]
        public void IntLiteralTest()
        {
            var f = _compiler.Compile<int>("555");
            f().ShouldEqual(555);
        }
        
        [Test]
        public void IntLiteralWithSuffixTest()
        {
            var f = _compiler.Compile<int>("555l");
            f().ShouldEqual(555);

            f = _compiler.Compile<int>("5l");
            f().ShouldEqual(5);
        }

        [Test]
        public void DecimalLiteralTest()
        {
            var f = _compiler.Compile<decimal>("555d");
            f().ShouldEqual(555m);
        }

        [Test]
        public void DecimalLiteralWithExponentTest()
        {
            var f = _compiler.Compile<decimal>("1.9e5");
            f().ShouldEqual(190000);
        }

        [Test]
        public void StringLiteralTest()
        {
            var f = _compiler.Compile<string>("\"abc\"");
            f().ShouldEqual("abc");
        }

        [Test]
        public void StringLiteralWithSlashTest()
        {

            var f = _compiler.Compile<string>(@"""hhh \ 99 """);
            f().ShouldEqual(@"hhh \ 99 ");
        }

        [Test]
        public void BooleanLiteralTest()
        {
            var f = _compiler.Compile<bool>("true");
            f().ShouldEqual(true);
        }

        [Test]
        public void StringConcatTest()
        {
            var f = _compiler.Compile<string>("\"abc\" + \"abc\"");
            f().ShouldEqual("abcabc");
        }
    }
}