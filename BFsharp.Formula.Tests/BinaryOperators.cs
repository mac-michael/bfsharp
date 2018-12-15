using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class BinaryOperators
    {
        private readonly FormulaCompiler _compiler = new FormulaCompiler();

        [Test]
        public void AddTest()
        {
            _compiler.Compile<int>("5+4")().ShouldEqual(9);
        }

        [Test]
        public void SubstractTest()
        {
            _compiler.Compile<int>("5-4")().ShouldEqual(1);
        }

        [Test]
        public void MultiplyTest()
        {
            _compiler.Compile<int>("5*4")().ShouldEqual(20);
        }

        [Test]
        public void DivideTest()
        {
            _compiler.Compile<int>("5/4")().ShouldEqual(5 / 4);
        }

        [Test]
        public void ModuloTest()
        {
            _compiler.Compile<int>("5%4")().ShouldEqual(1);
        }

        [Test]
        public void UnaryMinusTest()
        {
            _compiler.Compile<int>("-2")().ShouldEqual(-2);
        }

        [Test]
        public void UnaryDoubleMinusTest()
        {
            _compiler.Compile<int>("--2")().ShouldEqual(2);
        }

        [Test]
        public void UnaryMinusMinusTest()
        {
            _compiler.Compile<int>("-2-2")().ShouldEqual(-4);
        }

        [Test]
        public void AdditiveMultiplicativeTest()
        {
            _compiler.Compile<int>("2+2*2")().ShouldEqual(2 + 2 * 2);
        }

        [Test]
        public void ParenthesisTest()
        {
            _compiler.Compile<int>("(2+2)*2")().ShouldEqual((2 + 2) * 2);
        }

        [Test]
        public void EqualsTest()
        {
            var f = _compiler.Compile< bool>("5==3+2");
            f().ShouldEqual(true);
        }

        [Test]
        public void NotEqualsTest()
        {

            var f = _compiler.Compile<bool>("5!=5");
            f().ShouldEqual(false);
        }

        [Test]
        public void AndTest()
        {
            var f = _compiler.Compile<bool>("true && 4 == 4");
            f().ShouldEqual(true);
        }

        [Test]
        public void OrTest()
        {
            var f = _compiler.Compile<bool>("2==2 || 3 == 4");
            f().ShouldEqual(true);
        }

        [Test]
        public void GreaterOrEqualsTest()
        {
            var f = _compiler.Compile<bool>("2>=2");
            f().ShouldEqual(true);
        }

        [Test]
        public void LessOrEqualsTest()
        {
            var f = _compiler.Compile<bool>("2<=2");
            f().ShouldEqual(true);
        }

        [Test]
        public void GreaterTest()
        {
            var f = _compiler.Compile<bool>("4>2");
            f().ShouldEqual(true);
        }

        [Test]
        public void LessTest()
        {
            var f = _compiler.Compile<bool>("2<3");
            f().ShouldEqual(true);
        }
    }
}