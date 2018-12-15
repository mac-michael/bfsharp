using System;
using System.Collections.Generic;
using System.Reflection;

namespace BFsharp.Formula
{
    public class MathCallProvider : CallProviderBase
    {
        protected override IEnumerable<Method> GetMethods(Type type)
        {
            if (type == null)
            {
                foreach (var method in typeof (Math).GetMethods(BindingFlags.Public | BindingFlags.Static))
                    yield return method;
                //yield return typeof (Math).GetMethod("Abs", new[] {typeof (int)});
                //yield return typeof (Math).GetMethod("Abs", new[] {typeof (decimal)});

                //yield return typeof(Math).GetMethod("Max", new[] { typeof(decimal), typeof(decimal) });
                //yield return typeof(Math).GetMethod("Max", new[] { typeof(int), typeof(int) });

                //yield return typeof(Math).GetMethod("Min", new[] { typeof(decimal), typeof(decimal) });
                //yield return typeof(Math).GetMethod("Min", new[] { typeof(int), typeof(int) });
            }
        }
    }
}