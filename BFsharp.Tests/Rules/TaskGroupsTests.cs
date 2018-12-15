using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class TaskGroupsTests
    {
        [Test]
        public void Test()
        {
            var e = new Entity {Name = "g"};
            e.Extensions.CreateBusinessRule(a => a.Number + 1, a => a.Number2)
                .WithDisableValidation()
                .WithSwitch("g").Start();
            e.Extensions.CreateBusinessRule(a => a.Number2+1, a => a.Number)
                .WithDisableValidation()
                .WithSwitch("g2").Start();

            e.Extensions.CreateSwitchableRule(ex => ex.Name)
                .Start();

            //e.Extensions.CreateActionRule(a => a.Extensions.SwitchRulesByTag(a.Name))
              //  .WithModeAtStartup(ActionRuleStartupMode.Invoke).Enable();

            e.Number = 4;
            e.Number.ShouldEqual(4);
            e.Number2.ShouldEqual(5);

            e.Name = "g2";

            e.Number2 = 11;
            e.Number.ShouldEqual(12);
            e.Number2.ShouldEqual(11);
        }
    }
}