using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class ActionRuleTests
    {
        [Test]
        public void SimpleAction()
        {
            var e = new Entity();
            e.Extensions.CreateActionRuleWithoutDependency(en => { en.Number = en.Number2 + 1; })
                .WithDependencies(en => en.Number2).Enable();

            e.Number2++;

            e.Number.ShouldEqual(2);
        }

        [Test]
        public void SimpleActionWithAutoDependency()
        {
            var e = new Entity();
            e.Extensions.CreateActionRule(en => en.SetNumber2(en.Number + 1)).Enable();

            e.Number++;

            e.Number2.ShouldEqual(2);
        }
    }
}