using System.Linq;
using BFsharp.Tests;
using NUnit.Framework;

namespace BFsharp.Formula.Tests
{
    [TestFixture]
    public class Comments
    {
        readonly FormulaCompiler _compiler = new FormulaCompiler();

        [Test]
        public void LineComment()
        {
            var f = _compiler.Compile<int>(@"5 // abc");
            f().ShouldEqual(5);
        }

        [Test]
        public void LineCommentWithLineBreak()
        {
            var f = _compiler.Compile<int>(@"5 // abc
+ 5");
            f().ShouldEqual(10);
        }

        [Test]
        public void MultilineComment()
        {
            var f = _compiler.Compile<int>(@"5 + 5 /* abc */");
            f().ShouldEqual(10);
        }

        [Test]
        public void MultilineCommentOverLineBreak()
        {
            var f = _compiler.Compile<int>(@"5 /*
abc */ + 5");
            f().ShouldEqual(10);
        }

        [Test]
        public void MultilineCommentWithLineBreak()
        {
            var f = _compiler.Compile<int>(@"5 /* abc */
+ 5");
            f().ShouldEqual(10);
        }

        [Test]
        public void UnclosedComment()
        {
            _compiler.Compile<int>(@"5 /* abc + 5");

            _compiler.BuildInfo.Errors.Count().ShouldEqual(1);
        }
    }
}