using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
#if PHONE
using ExpressionCompiler;
#endif 

namespace BFsharp.Formula
{
    public partial class FormulaCompiler
    {
        public FormulaCompiler() 
            : this(new FormulaASTVisitor()) {}

        public FormulaCompiler(IASTTranslator translator)
        {
            _translator = translator;
            BuildInfo = new BuildInfo();
        }

        public FormulaCompiler WithInfo(FormulaCompilerBuildInfoLevels buildInfo)
        {
            BuildInfo.Level = buildInfo;
            return this;
        }

        public BuildInfo BuildInfo { get; private set; }

        public ICallProvider CallProvider { get; set; }
        private readonly IASTTranslator _translator;

        public Lambda NewLambda()
        {
            return new Lambda(this);
        }

        public Func<TReturn> Compile<TReturn>(string formula)
        {
            var definition = new LambdaTypeDefinition {ReturnedType = typeof (TReturn)};

            return CompileToExpression<Func<TReturn>>(formula, definition)
                .Compile();
        }

        internal Expression<T> CompileToExpression<T>(string formula, LambdaTypeDefinition definition)
        {
            BuildInfo.Clear();

            var tree = Parse(formula);
            if (tree == null) return null;

            return _translator.Translate<T>(tree, definition, CallProvider, BuildInfo);
        }

        private CommonTree Parse(string formula)
        {
            var m = new MemoryStream(Encoding.UTF8.GetBytes(formula));

            // create a CharStream that reads from standard input
            var input = new ANTLRInputStream(m);

            // create a lexer that feeds off of input CharStream
            var lexer = new FormulaLexer(input);
            // create a buffer of tokens pulled from the lexer
            var tokens = new CommonTokenStream(lexer);
            // create a parser that feeds off the tokens buffer

            var parser = new FormulaParser(tokens);
            var tree = parser.start();

            var errors = lexer.GetErrors().Union(parser.GetErrors());

            foreach (var error in errors)
                BuildInfo.Log(error.ToString(), FormulaCompilerBuildInfoLevels.Error);                

            if (errors.Count() > 0)
                return null;

            var root = (CommonTree) tree.Tree;

            BuildInfo.Log(root.ToStringTree(), FormulaCompilerBuildInfoLevels.AST);

            return root;
        }
    }
}