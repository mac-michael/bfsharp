using System;
using System.Collections.Generic;

namespace BFsharp.Formula
{
    public partial class FormulaCompiler
    {
        private FormulaCompiler With(ICallProvider provider)
        {
            if (CallProvider == null)
                CallProvider = provider;
            else
            {
                if (CallProvider is AggregateCallProvider)
                    ((AggregateCallProvider) CallProvider).Register(provider);
                else
                    CallProvider = new AggregateCallProvider()
                    .Register(CallProvider)
                    .Register(provider);
            }

            return this;
        }

        public FormulaCompiler With(params ICallProvider[] providers)
        {
            foreach (var provider in providers)
                With(provider);

            return this;
        }

        public FormulaCompiler WithMath()
        {
            return With(new MathCallProvider());
        }

        public FormulaCompiler WithDate()
        {
            return With(new DateCallProvider());
        }

        public FormulaCompiler WithFlatType(Type type)
        {
            return WithFlatType(type, null);
        }

        public FormulaCompiler WithFlatType(Type type, Type requiredAttribute)
        {
            return With(new FlatTypeCallProvider(type, requiredAttribute));
        }

        public FormulaCompiler WithType<T>()
        {
            return WithType<T>(null);
        }

        public FormulaCompiler WithType<T>(Type requiredAttribute)
        {
            return With(new TypeCallProvider(typeof(T),requiredAttribute));
        }

        public FormulaCompiler WithType<T, U>()
        {
            return WithType<T, U>(null);
        }

        public FormulaCompiler WithType<T, U>(Type requiredAttribute)
        {
            With(new TypeCallProvider(typeof(T), requiredAttribute));
            return With(new TypeCallProvider(typeof(U),requiredAttribute));
        }

        public FormulaCompiler WithType<T, U, V>()
        {
            return WithType<T, U, V>(null);
        }

        public FormulaCompiler WithType<T, U, V>(Type requiredAttribute)
        {
            With(new TypeCallProvider(typeof(T),requiredAttribute));
            With(new TypeCallProvider(typeof(U), requiredAttribute));
            return With(new TypeCallProvider(typeof(V),requiredAttribute));
        }

        public FormulaCompiler WithLinq()
        {
            return With( new AssemblyCallProvider()
                .AddAssembly(typeof(System.Linq.Enumerable).Assembly)
                .Using("System.Linq")
                .WithExtensionMethods());
        }

        public FormulaCompiler WithSystem()
        {
            return With(new AssemblyCallProvider()
                            .AddAssembly(typeof(string).Assembly)
                            .Using("System"));
        }

        private static FormulaCompiler _compiler;

        public static FormulaCompiler Instance
        {
            get
            {
                if (_compiler == null)
                {
                    _compiler = new FormulaCompiler().WithSystem();
                } 
                return _compiler;
            }
        }
    }
}