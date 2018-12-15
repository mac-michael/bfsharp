using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace BFsharp
{
    public enum RuleDebuggerEntrySeverity
    {
        None,
        Warning,
        Exception,
    }

    public static class RuleDebugger
    {
        static RuleDebugger()
        {
            Enabled = true;
        }

        public static RuleDebuggerEntrySeverity ParentChangeWarning { get; set; }

        internal static void CheckParentChanged( object target, IEntityExtensions oldParent, IEntityExtensions newParent )
        {
            if (ParentChangeWarning == RuleDebuggerEntrySeverity.None) return;

            if (oldParent != null && newParent != null && oldParent != newParent)
            {
                var message =
                    string.Format("Parent of entity {0} was changed from {1} to {2}, possible buggy behaviour.",
                                  target, oldParent, newParent);

                CheckInternal(ParentChangeWarning, message);
            }
        }

        internal static void CheckInternal(RuleDebuggerEntrySeverity severity, string message)
        {
            if (severity == RuleDebuggerEntrySeverity.Exception)
                throw new InvalidOperationException(message);
            if (severity == RuleDebuggerEntrySeverity.Warning)
                Warning(message);
        }

        public static RuleDebuggerEntrySeverity NoNotifyPropertyChangedWarning { get; set; }

        internal static bool CheckNoNotifyPropertyChangedWarning(object target)
        {
            var implemented = target is INotifyPropertyChanged;

            if (!implemented)
                CheckInternal( NoNotifyPropertyChangedWarning, string.Format("Object {0} does not implement INotifyPropertyChanged.",target));

            return implemented;
        }

        public static RuleDebuggerEntrySeverity NoNotifyCollectionChangedWarning { get; set; }

        internal static bool CheckNoNotifyCollectionChangedWarning(object target)
        {
            var implemented = target is INotifyCollectionChanged;

            if (!implemented)
                CheckInternal(NoNotifyCollectionChangedWarning, string.Format("Object {0} does not implement INotifyCollectionChanged.", target));

            return implemented;
        }    

        public static RuleDebuggerEntrySeverity ClosureWarning { get; set; }

        internal static void CheckClosureWarning(Type type, Expression expression)
        {
            if (ClosureWarning == RuleDebuggerEntrySeverity.None) return;

            if (type.Name.StartsWith("<>") && type.IsDefined(typeof (CompilerGeneratedAttribute), true))
                CheckInternal(ClosureWarning, "Possible closure warning in expression: " + expression);
        }

        public static bool Enabled { get; set; }
        private static void WriteLine(string info)
        {
            if (Enabled)
                Debug.WriteLine(info);
        }

        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            WriteLine(message);
        }

        [Conditional("DEBUG")]
        public static void Info(string format, string text1, string text2)
        {
            Info(string.Format(format, text1, text2));
        }

        [Conditional("DEBUG")]
        public static void Warning(string message)
        {
            WriteLine(message);
        }

        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            WriteLine(message);
        }
    }
}
