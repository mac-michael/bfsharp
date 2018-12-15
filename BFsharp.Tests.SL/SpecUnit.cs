using System;
using System.Collections;
using NUnit.Framework;

namespace SpecUnit
{
    public static class SpecificationExtensions
    {
        public static void ShouldBeFalse(this bool condition)
        {
            Assert.IsFalse(condition);
        }
        
        public static void ShouldBeNull(this object anObject)
        {
            Assert.IsNull(anObject);
        }

        public static void ShouldBeOfType(this object actual, Type expected)
        {
            Assert.IsInstanceOfType(expected, actual.GetType());
        }

        public static void ShouldBeSurroundedWith(this string actual, string expectedDelimiter)
        {
            StringAssert.StartsWith(expectedDelimiter, actual);
            StringAssert.EndsWith(expectedDelimiter, actual);
        }

        public static void ShouldBeSurroundedWith(this string actual, string expectedStartDelimiter, string expectedEndDelimiter)
        {
            StringAssert.StartsWith(expectedStartDelimiter, actual);
            StringAssert.EndsWith(expectedEndDelimiter, actual);
        }

        public static object ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.AreSame(expected, actual);
            return expected;
        }
        
        public static void ShouldBeTrue(this bool condition)
        {
            Assert.IsTrue(condition);
        }
        
        public static void ShouldContain(this string actual, string expected)
        {
            StringAssert.Contains(expected, actual);
        }

        public static void ShouldContainErrorMessage(this Exception exception, string expected)
        {
            StringAssert.Contains(expected, exception.Message);
        }

        public static void ShouldEndWith(this string actual, string expected)
        {
            StringAssert.EndsWith(expected, actual);
        }

        public static object ShouldEqual(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
            return expected;
        }

        public static void ShouldNotBeNull(this object anObject)
        {
            Assert.IsNotNull(anObject);
        }

        public static void ShouldNotBeOfType(this object actual, Type expected)
        {
            Assert.IsNotInstanceOfType(expected, actual.GetType());
        }

        public static object ShouldNotBeTheSameAs(this object actual, object expected)
        {
            Assert.AreNotSame(expected, actual);
            return expected;
        }

        public static void ShouldNotContain(this IList collection, object expected)
        {
            CollectionAssert.DoesNotContain(collection, expected);
        }

        public static object ShouldNotEqual(this object actual, object expected)
        {
            Assert.AreNotEqual(expected, actual);
            return expected;
        }

        public static void ShouldStartWith(this string actual, string expected)
        {
            StringAssert.StartsWith(expected, actual);
        }
    }


}
