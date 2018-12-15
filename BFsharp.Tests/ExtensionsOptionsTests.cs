using System;
using System.Linq.Expressions;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture, Ignore]
    public class ExtensionsOptionsTests
    {
        [Test]
        public void Test()
        {
            ExtensionsOptions<EntityWithBase>.Instance
                .Reset()
                .WithRulePrototype()
                .WithDecorator()
                .WithRuleInitializer()
                .WithBuiltInGraphMonitoringStrategy(PredefinedGraphMonitoringStrategy.No);

            ExtensionsOptions<Entity>.Instance
                .WithManualGraphMonitoringStrategy()
                .WithProperties(p => p.Number, p => p.Number2)
                .WithCollections(p => p.Collection);

            var a = ExtensionsOptions<EntityWithBase>.Instance
                .WithRulePrototype();

            var i = ExtensionsOptions<RuleInitializerEntity>.Instance;
        }


    }
}