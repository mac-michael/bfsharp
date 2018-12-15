using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BFsharp.Caching;
using BFsharp.Localization;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class CacheTests
    {
        public class Entity2
        {
            public int Number { get; set; }    
        }

        [Test]
        public void ClosureCaching()
        {
            var hashes = new List<int>();
            int n = 5;
            for (int i = 0; i < 2; i++)
            {
                Expression<Func<Entity, bool>> expression = e => e.Number == n;
                hashes.Add(ExpressionEqualityComparer.Instance.GetHashCode(expression));
            }

            hashes[0].ShouldEqual(hashes[1]);
        }
        
        [Test]
        public void AntiClosureCaching()
        {
            var hashes = new List<int>();
            for (int i = 0; i < 2; i++)
            {
                int n = 5;
                Expression<Func<Entity, bool>> expression = e => e.Number == n;
                hashes.Add(ExpressionEqualityComparer.Instance.GetHashCode(expression));
            }

            hashes[0].ShouldNotEqual(hashes[1]);
        }

        [Test]
        public void AntiClosureCaching2()
        {
            var hashes = new List<int>();
            for (int i = 0; i < 2; i++)
            {
                int n = i + 4;
                Expression<Func<Entity, bool>> expression = e => e.Number == n;
                hashes.Add(ExpressionEqualityComparer.Instance.GetHashCode(expression));
            }

            hashes[0].ShouldNotEqual(hashes[1]);
        }
    }
}