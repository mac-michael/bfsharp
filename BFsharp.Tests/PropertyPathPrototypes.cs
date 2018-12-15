using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture, Ignore]
    public class PropertyPathPrototypes
    {
        [Test]
        public void Test()
        {
            new PropertyPath("$abcsaf.a")[1].Type.ShouldEqual(PropertyPathElementType.Property);
            new PropertyPath("abc.abc.c$aasd.44$a")[3].Type.ShouldEqual(PropertyPathElementType.CollectionElement);
            new PropertyPath("abc$cc")[0].Type.ShouldEqual(PropertyPathElementType.Property);
        }
    }
}