using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace BFsharp
{
    public enum RuleContextState
    {
        Client,
        Server,
        Unknown
    }

    internal class RuleContextBuilInStrategy
    {
#if NET
        static RuleContextBuilInStrategy()
        {
            GetHttpContext = GetProperty("System.Web", "System.Web.HttpContext", "Current");
            GetOperationContext = GetProperty("System.ServiceModel", "System.ServiceModel.OperationContext", "Current");
        }

        private static Func<object> GetProperty(string assembly, string type, string property)
        {
            var ass = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GetName().Name == assembly).FirstOrDefault();
            if (ass == null) return () => null;

            var t = ass.GetType(type, false);
            if (t == null) return () => null;
            var c = t.GetProperty("Current", BindingFlags.Public | BindingFlags.Static);

            return Expression.Lambda<Func<object>>(Expression.Property(null, c)).Compile();
        }

        static readonly Func<object> GetHttpContext;
        static readonly Func<object> GetOperationContext;
#endif
        public static RuleContextState State
        {
            get
            {
#if SILVERLIGHT || PHONE
            return RuleContextState.Client;
#elif NET
                if (GetHttpContext() != null || GetOperationContext() != null)
                    return RuleContextState.Server;
#endif
                return RuleContextState.Client;
            }
        }
    }

    public class RuleContext
    {
        public static Func<RuleContextState> Strategy = () => RuleContextBuilInStrategy.State;
        public static RuleContextState State
        {
            get { return Strategy(); }
        }
    }
}