using System;
using System.Collections.Generic;
using BFsharp.DynamicProperties;
using BFsharp.Formula;
using BFsharp.FormulaExtensions;

namespace BFsharp
{
    public static class FormulaCompilerExtensions
    {
        public static FormulaCompiler WithDynamicEntity(this FormulaCompiler compiler, 
            Type thisType , bool allowDynamicProperties, IEnumerable<DynamicPropertyMetadata> properties)
        {
            return compiler.With(new DynamicPropertyProvider(thisType, allowDynamicProperties, properties));
        }
    }
}