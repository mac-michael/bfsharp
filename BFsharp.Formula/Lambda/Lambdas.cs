using System;
using System.Linq.Expressions;
#if PHONE
using ExpressionCompiler;
#endif

namespace BFsharp.Formula
{
	public partial class Lambda<T1>
    {		
		internal Lambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Lambda<T1,T> WithParam<T>(string paramName)
        {
			Definition.Params.Add( new Param(typeof(T), paramName ) );
            return new Lambda<T1,T>(Definition, Compiler);
        }

        public CompilableLambda<T1,T> Returns<T>()
        {
			Definition.ReturnedType = typeof(T);
            return new CompilableLambda<T1,T>(Definition, Compiler);
        }
    }
	public partial class Lambda<T1,T2>
    {		
		internal Lambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Lambda<T1,T2,T> WithParam<T>(string paramName)
        {
			Definition.Params.Add( new Param(typeof(T), paramName ) );
            return new Lambda<T1,T2,T>(Definition, Compiler);
        }

        public CompilableLambda<T1,T2,T> Returns<T>()
        {
			Definition.ReturnedType = typeof(T);
            return new CompilableLambda<T1,T2,T>(Definition, Compiler);
        }
    }
	public partial class Lambda<T1,T2,T3>
    {		
		internal Lambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Lambda<T1,T2,T3,T> WithParam<T>(string paramName)
        {
			Definition.Params.Add( new Param(typeof(T), paramName ) );
            return new Lambda<T1,T2,T3,T>(Definition, Compiler);
        }

        public CompilableLambda<T1,T2,T3,T> Returns<T>()
        {
			Definition.ReturnedType = typeof(T);
            return new CompilableLambda<T1,T2,T3,T>(Definition, Compiler);
        }
    }
    public class CompilableLambda<T1>
    {
		internal CompilableLambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Func<T1> Compile(string formula)
        {
            var ex = CompileToExpression(formula);
			
			return ex != null ? ex.Compile() : null;
        }
        
        public Expression<Func<T1>> CompileToExpression(string formula)
        {
            return Compiler.CompileToExpression<Func<T1>>(formula, Definition);
        }
        
    }
    
    public class CompilableLambda<T1,T2>
    {
		internal CompilableLambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Func<T1,T2> Compile(string formula)
        {
            var ex = CompileToExpression(formula);
			
			return ex != null ? ex.Compile() : null;
        }
        
        public Expression<Func<T1,T2>> CompileToExpression(string formula)
        {
            return Compiler.CompileToExpression<Func<T1,T2>>(formula, Definition);
        }
        
    }
    
    public class CompilableLambda<T1,T2,T3>
    {
		internal CompilableLambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Func<T1,T2,T3> Compile(string formula)
        {
            var ex = CompileToExpression(formula);
			
			return ex != null ? ex.Compile() : null;
        }
        
        public Expression<Func<T1,T2,T3>> CompileToExpression(string formula)
        {
            return Compiler.CompileToExpression<Func<T1,T2,T3>>(formula, Definition);
        }
        
    }
    
    public class CompilableLambda<T1,T2,T3,T4>
    {
		internal CompilableLambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Func<T1,T2,T3,T4> Compile(string formula)
        {
            var ex = CompileToExpression(formula);
			
			return ex != null ? ex.Compile() : null;
        }
        
        public Expression<Func<T1,T2,T3,T4>> CompileToExpression(string formula)
        {
            return Compiler.CompileToExpression<Func<T1,T2,T3,T4>>(formula, Definition);
        }
        
    }
    
    public class CompilableLambda<T1,T2,T3,T4,T5>
    {
		internal CompilableLambda(LambdaTypeDefinition definition, FormulaCompiler compiler)
		{
			Definition = definition;
			Compiler = compiler;
		}
        private LambdaTypeDefinition Definition { get; set; }
        private FormulaCompiler Compiler { get; set; }

        public Func<T1,T2,T3,T4,T5> Compile(string formula)
        {
            var ex = CompileToExpression(formula);
			
			return ex != null ? ex.Compile() : null;
        }
        
        public Expression<Func<T1,T2,T3,T4,T5>> CompileToExpression(string formula)
        {
            return Compiler.CompileToExpression<Func<T1,T2,T3,T4,T5>>(formula, Definition);
        }
        
    }
    
}
