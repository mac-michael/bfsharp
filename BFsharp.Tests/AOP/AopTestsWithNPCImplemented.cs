using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class AopTestsWithNPCImplemented
    {
        [Test]
        public void NotifyPropertyChanged()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.A += 1;

            t.PropertyShouldBeNotified("A");
        }

        [Test]
        public void DoubleNotifyPropertyChanged()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.A += 1;
            e.A += 1;

            t.PropertyShouldBeNotified("A", 2);
        }

        [Test]
        public void EqualValueSet()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.A = 1;
            e.A = 1;

            t.PropertyShouldBeNotified("A", 1);
        }

        [Test]
        public void DontNotify()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.B += 1;

            t.PropertyShouldBeNotified("B", 0);
        }

        [Test]
        public void DependentNotify()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.A += 1;
            e.A2 += 1;

            t.PropertyShouldBeNotified("CalculatedA", 2);
        }

        [Test]
        public void RecursiveDependenttNotify()
        {
            var e = new AopTestEntityWithNPC();
            var t = PropertyChangedTracker.Create(e);

            e.A += 1;
            e.A2 += 1;

            t.PropertyShouldBeNotified("RecursiveA", 2);
        }
    }
}