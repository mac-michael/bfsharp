using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class AopTests
    {
        [Test]
        public void NotifyPropertyChanged()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.A+=1;

            PropertyShouldBeNotified("A");
        }

        [Test]
        public void DoubleNotifyPropertyChanged()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.A += 1;
            e.A += 1;

            PropertyShouldBeNotified("A", 2);
        }

        [Test]
        public void EqualValueSet()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.A = 1;
            e.A = 1;

            PropertyShouldBeNotified("A", 1);
        }

        [Test]
        public void DontNotify()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.B += 1;

            PropertyShouldBeNotified("B", 0);
        }

        [Test]
        public void DependentNotify()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.A += 1;
            e.A2 += 1;

            PropertyShouldBeNotified("CalculatedA", 2);
        }

        [Test]
        public void RecursiveDependenttNotify()
        {
            var e = new AopTestEntity();
            InitPropertiesTracking(e);

            e.A += 1;
            e.A2 += 1;

            PropertyShouldBeNotified("RecursiveA", 2);
        }

        private Dictionary<string, int> _properties;
        private void InitPropertiesTracking(object target)
        {
            _properties = new Dictionary<string, int>();
            var npc = (INotifyPropertyChanged) target;

            npc.PropertyChanged += OnPropertyChanged;
        }

        private void PropertyShouldBeNotified(string propertyName)
        {
            PropertyShouldBeNotified(propertyName, 1);
        }

        private void PropertyShouldBeNotified(string propertyName, int count)
        {
            int value;
            if (!_properties.TryGetValue(propertyName, out value))
                value = 0;

            value.ShouldEqual(count);
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            int value;
            if ( !_properties.TryGetValue(e.PropertyName, out value))
                _properties.Add(e.PropertyName, value = 0);

            _properties[e.PropertyName] = value + 1;
        }
    }
}