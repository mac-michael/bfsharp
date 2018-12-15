using System;
using System.Diagnostics;

namespace BFsharp.Formula.Tests
{
    public class TestTime : IDisposable
    {
        private Stopwatch _s;

        public static TestTime Start()
        {
            return new TestTime { _s = Stopwatch.StartNew() };
        }
        public static void Start(double iterations, Action action)
        {
            Start((int)iterations, action);
        }

        public static void Start(int iterations, Action action)
        {
            Debug.WriteLine("Iteration: 1");
            var w = Stopwatch.StartNew();

            action();
            w.Stop();
            long firstIterationTime = w.ElapsedMilliseconds;
            Console.WriteLine("First iteration: {0}ms", firstIterationTime);

            if (iterations == 1) return;

            Debug.WriteLine("Iterations: 2.." + iterations);
            w.Start();
            for (int i = 1; i < iterations; i++)
                action();

            w.Stop();
            Console.WriteLine("Total time (without first iteration): {0}ms", w.ElapsedMilliseconds - firstIterationTime);
            Console.WriteLine("Total time: {0}ms", w.ElapsedMilliseconds);
            Console.WriteLine("Average time (without first iteration): {0}ms",
                              (w.ElapsedMilliseconds - firstIterationTime) / (decimal)(iterations - 1));
            Console.WriteLine("Average time: {0}ms", w.ElapsedMilliseconds / (decimal)iterations);
        }

        public static void Measure(double miliseconds, Action action)
        {
            Measure((int)miliseconds, action);
        }

        public static void Measure(int miliseconds, Action action)
        {
            Debug.WriteLine("Iteration: 1");
            var w = Stopwatch.StartNew();

            action();
            w.Stop();
            long firstIterationTime = w.ElapsedMilliseconds;
            Console.WriteLine("First iteration: {0}ms", firstIterationTime);

            Debug.WriteLine("Iterations: 2..");
            w.Start();
            int iterations = 0;
            for (; w.ElapsedMilliseconds < miliseconds; iterations++)
                action();

            w.Stop();
            Console.WriteLine("Total time (without first iteration): {0}ms", w.ElapsedMilliseconds - firstIterationTime);
            Console.WriteLine("Total iterations: {0}", iterations);

            Console.WriteLine("Average time (without first iteration): {0}ms",
                              (w.ElapsedMilliseconds - firstIterationTime) / (decimal)(iterations - 1));
            Console.WriteLine("Average time: {0}ms", w.ElapsedMilliseconds / (decimal)iterations);
        }

        public void Dispose()
        {
            _s.Stop();
            Console.WriteLine(_s.ElapsedMilliseconds);
        }
    }
}