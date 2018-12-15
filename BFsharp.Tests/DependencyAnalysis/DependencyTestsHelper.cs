using System;
using System.ComponentModel;
using System.Reflection;
using BFsharp.Authoring;
using NUnit.Framework;

namespace BFsharp.Tests
{
    static class DependencyTestsHelper
    {
        private static FieldInfo GetField(Type type, string name)
        {
            var t = type;
            while (t != null)
            {
                var f = t.GetField(name, BindingFlags.NonPublic
                                         | BindingFlags.Instance);
                if (f != null)
                    return f;
                t = t.BaseType;
            }

            return null;
        }

        public static PropertyChangedEventHandler GetPropertyChangeEventHandler(this object obj)
        {
            var propertyChangedInfo = GetField(obj.GetType(), "PropertyChanged");
            
            var p = (PropertyChangedEventHandler)propertyChangedInfo.GetValue(obj);

            return p;
        }

        public static int GetPropertyChangeSubscriptionCount(this object obj)
        {
            var p = GetPropertyChangeEventHandler(obj);

            return p == null ? 0 : p.GetInvocationList().Length;
        }

        public static void PropertyChangeSubscriptionCountShouldEqual(this object obj, int subscriptionCount)
        {
            obj.GetPropertyChangeSubscriptionCount().ShouldEqual(subscriptionCount);
        }

        public static bool ContainsProperty(this object obj, string propertyName, Type propertyType)
        {
            var p = obj.GetType().GetProperty(propertyName);
            if (p == null) return false;

            return p.PropertyType == propertyType;
        }
    }
}