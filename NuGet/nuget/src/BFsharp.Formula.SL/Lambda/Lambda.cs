namespace BFsharp.Formula
{
    public class Lambda
    {
        internal Lambda(FormulaCompiler compiler)
        {
            Definition = new LambdaTypeDefinition();
            Compiler = compiler;
        }

        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Lambda<T> WithParam<T>(string paramName)
        {
            Definition.Params.Add(new Param(typeof(T), paramName));
            return new Lambda<T>(Definition, Compiler);
        }

        public CompilableLambda<T> Returns<T>()
        {
            Definition.ReturnedType = typeof(T);
            return new CompilableLambda<T>(Definition, Compiler);
        }

        public Lambda<T> WithThis<T>()
        {
            Definition.ThisType = typeof(T);
            return new Lambda<T>(Definition, Compiler);
        }
    }

    public class Lambda<T1, T2, T3, T4>
    {
        internal Lambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
        {
            Definition = definition;
            Compiler = compiler;
        }

        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public CompilableLambda<T1, T2, T3, T4, T> Returns<T>()
        {
            return new CompilableLambda<T1, T2, T3, T4, T>(Definition, Compiler);
        }
    }
}