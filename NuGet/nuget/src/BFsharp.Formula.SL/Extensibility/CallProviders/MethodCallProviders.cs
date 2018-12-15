using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public class MethodCallProvider<T1> : CallProviderBase
    {
        private readonly Method _method;

        public MethodCallProvider(string name, Func<T1> method)
        {
            _method = new Method(method.Method);
            _method.Name = name;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type == null)
                yield return _method;
        }
    }
    
    public partial class FormulaCompiler
    {
		public FormulaCompiler WithMethod<T1>(string name, Func<T1> method)
        {
            return With(new MethodCallProvider<T1>(name, method));
        }
    }
    
    public class MethodCallProvider<T1,T2> : CallProviderBase
    {
        private readonly Method _method;

        public MethodCallProvider(string name, Func<T1,T2> method)
        {
            _method = new Method(method.Method);
            _method.Name = name;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type == null)
                yield return _method;
        }
    }
    
    public partial class FormulaCompiler
    {
		public FormulaCompiler WithMethod<T1,T2>(string name, Func<T1,T2> method)
        {
            return With(new MethodCallProvider<T1,T2>(name, method));
        }
    }
    
    public class MethodCallProvider<T1,T2,T3> : CallProviderBase
    {
        private readonly Method _method;

        public MethodCallProvider(string name, Func<T1,T2,T3> method)
        {
            _method = new Method(method.Method);
            _method.Name = name;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type == null)
                yield return _method;
        }
    }
    
    public partial class FormulaCompiler
    {
		public FormulaCompiler WithMethod<T1,T2,T3>(string name, Func<T1,T2,T3> method)
        {
            return With(new MethodCallProvider<T1,T2,T3>(name, method));
        }
    }
    
    public class MethodCallProvider<T1,T2,T3,T4> : CallProviderBase
    {
        private readonly Method _method;

        public MethodCallProvider(string name, Func<T1,T2,T3,T4> method)
        {
            _method = new Method(method.Method);
            _method.Name = name;
        }

        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type == null)
                yield return _method;
        }
    }
    
    public partial class FormulaCompiler
    {
		public FormulaCompiler WithMethod<T1,T2,T3,T4>(string name, Func<T1,T2,T3,T4> method)
        {
            return With(new MethodCallProvider<T1,T2,T3,T4>(name, method));
        }
    }
    
}
