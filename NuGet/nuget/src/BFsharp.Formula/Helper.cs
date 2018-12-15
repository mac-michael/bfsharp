using System;

namespace BFsharp.Formula
{
    partial class Helpers
    {
        public static bool TypeArrayEquals(Type[] types, Type[] types2)
        {
            if (types.Length != types2.Length)
                return false;

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i] != types2[i])
                    return false;
            }

            return true;
        }

        public static T[] Combine<T>(T one, T[] tail)
        {
            var p = new T[tail.Length + 1];
            p[0] = one;
            for (int i = 0; i < tail.Length; i++)
                p[i+1] = tail[i];

            return p;
        }

        public static IDisposable Disposable(Action startAction, Action disposeAction)
        {
            startAction();
            return new DisposableClass { DisposableAction = disposeAction };
        }

        class DisposableClass : IDisposable
        {
            internal Action DisposableAction { private get; set; }
            public void Dispose()
            {
                DisposableAction();
            }
        }
    }
}