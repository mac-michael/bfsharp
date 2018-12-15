using System;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class RuleDebugger
    {
        public class EntityWithoutNPC
        {
            public string Name { get; set; }
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionWhenNoNPC()
        {
            BFsharp.RuleDebugger.NoNotifyPropertyChangedWarning = RuleDebuggerEntrySeverity.Exception;

            var e = new EntityWithoutNPC();
            var ee= EntityExtensions.RegisterTypedObject(e);
            ee.CreateValidationRule(x => x.Name.Length > 3)
                .Start();
        }

        public string Name { get; set; }

        [Test, Ignore]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ThrowExceptionWhenClosure()
        {
            BFsharp.RuleDebugger.ClosureWarning = RuleDebuggerEntrySeverity.Exception;

            var e = new EntityWithoutNPC();
            var ee = EntityExtensions.RegisterTypedObject(e);
            
            ee.CreateValidationRule(x => x.Name.Length != Name.Length)
                .WithModeAtStartup(ValidationRuleStartupMode.None)
                .Start();
        }
    }
}