using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class AttributedValidationRuleTests
    {
        [NotifyPropertyChanged]
        public class AttributedEntity : EntityBase<AttributedEntity>
        {
            [Range(Low = 4)]
            public int Number { get; set; }
        }
        [Test]
        public void RangeLowTest()
        {
            var e = new AttributedEntity();
            e.Extensions.InitializeRules();

            e.Extensions.IsValid.ShouldBeFalse();
            e.Number = 5;
            e.Extensions.IsValid.ShouldBeTrue();
        }
    }
}
