using System.Collections.Generic;
using System.ComponentModel;

namespace BFsharp.Tests
{
    internal class PropertyChangedTracker
    {
        private readonly Dictionary<string, int> _properties = new Dictionary<string, int>();

        public static PropertyChangedTracker Create(object target)
        {
            var p = new PropertyChangedTracker();
            var npc = (INotifyPropertyChanged)target;

            npc.PropertyChanged += p.OnPropertyChanged;
            return p;
        }

        public void PropertyShouldBeNotified(string propertyName)
        {
            PropertyShouldBeNotified(propertyName, 1);
        }

        public void PropertyShouldBeNotified(string propertyName, int count)
        {
            int value;
            if (!_properties.TryGetValue(propertyName, out value))
                value = 0;

            value.ShouldEqual(count);
        }

        void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            int value;
            if (!_properties.TryGetValue(e.PropertyName, out value))
                _properties.Add(e.PropertyName, value = 0);

            _properties[e.PropertyName] = value + 1;
        }
    }
}