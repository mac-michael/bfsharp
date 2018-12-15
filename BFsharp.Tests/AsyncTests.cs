using System;
using System.Diagnostics;
using System.Linq.Expressions;
//using System.Threading;
//using System.Threading.Tasks;
using NUnit.Framework;

namespace BFsharp.Tests
{
//    class UnitTestSynchronizationContext : SynchronizationContext
//    {
//        public override void Post(SendOrPostCallback d, object state)
//        {
//            ThreadPool.QueueUserWorkItem(c => d(state));
//        }

//        public override void Send(SendOrPostCallback d, object state)
//        {
//            ThreadPool.QueueUserWorkItem(c => d(state));
//        }
//    }

//    [TestFixture, Ignore]
//    public class AsyncTests
//    {
//        [TestFixtureSetUp]
//        public void TestInit()
//        {
//            SynchronizationContext.SetSynchronizationContext(
//                new UnitTestSynchronizationContext());
//        }

//        [Test]
//        public void AsyncAction()
//        {
//            var d = new Entity();
//            bool awaited = false;
//            var rule = d.Extensions.CreateActionRuleWithoutDependency(async p =>
//                                                    {
//                                                        await TaskEx.Delay(5);
//                                                        awaited = true;
//                                                    }
//                                                    )
//                .Start();

//            rule.Invoke();
//            awaited.ShouldBeTrue();
//            Thread.Sleep(1000);
//        }

//        [Test]
//        public void ExceptionAction()
//        {
//            var d = new Entity();
//            var rule = d.Extensions.CreateActionRuleWithoutDependency(async p =>
//                {
//                    await TaskEx.Delay(400);
//                    Debug.WriteLine("error");
//                    throw new InvalidOperationException();
//                }
//            ).Start();

//            rule.WithException<Exception>("error", BrokenRuleSeverity.Error);
//            rule.Invoke();

//            Thread.Sleep(1000);
//        }

//        [Test]
//        public async void Abc2()
//        {
//            var d = new Entity();
//            d.Extensions.CreateActionRule(p => Debug.WriteLine(p.Number))
//                .WithDelay(100)
//                .Start();

//            Debug.WriteLine("Yo");
            
//            d.Number = 5;

//            Thread.Sleep(10000);
//            await TaskEx.Delay(1000);
//        }
//    }

//    public static class ExtensionsX
//    {
//        public static BusinessRule<T, V> CreateBusinessRuleX<T, V>(this IEntityExtensions<T> extension,
//            Func<T, Task<V>> func, Expression<Func<T, V>> target)
//        {
//            //var c = target.Compile();
//            //var factory = new RuleFactory<T>();
//            //var rule = factory.CreateBusinessRule(func, target);

//            var synchronizationContext = new SynchronizationContext();
//            SynchronizationContext.SetSynchronizationContext(synchronizationContext);


//            A();

//            //extension.Rules.Add(rule); 
//            return null;
//        }
//#pragma warning disable 1998
//        public static void B()
//        {

//        }

//        public static async void A()
//        {
//            await
//            TaskEx.Delay(4);
//            B();
//        }

//        public static T WithDelay<T>(this T rule, int delay)
//            where T : ActionRule
//        {
//          //  rule.Delay = delay;
//            return rule;
//        }
//    }
}